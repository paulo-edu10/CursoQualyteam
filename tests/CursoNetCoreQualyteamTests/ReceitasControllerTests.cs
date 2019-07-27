using System;
using Xunit;
using FluentAssertions;
using cursonetcorequalyteam.Controllers;
using Microsoft.EntityFrameworkCore;
using cursonetcorequalyteam.Infraestrutura;
using cursonetcorequalyteam.Dominio;
using System.Linq;

namespace CursoNetCoreQualyteam.Controllers.Tests
{
    public class ReceitasControllerTests
    {

        private ReceitasContext CreateTestContext()
        {
            var options = new DbContextOptionsBuilder<ReceitasContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            return new ReceitasContext(options);
        }

        [Fact]
        public void Get_DeveResponderComTodasAsReceitasCadastradas()
        {
           var receitasCadastradas = cadastrarReceitas();


            var context = CreateTestContext();

            context.AddRange(receitasCadastradas);
            context.SaveChanges();

            var controller = new ReceitasController(context);
            var receitas = controller.Get();

            receitas.Value.Should().BeEquivalentTo(new ReceitasViewModel[]{

                new ReceitasViewModel(){

                Id = 1,
                Title = "Batata frita",
                Description = "Batata frita é aquele acompanhamento do qual todo mundo gosta e também é um aperitivo delicioso.",
                ImageUrl = "https://img.elo7.com.br/product/original/1DEEFB7/caixinha-embalagem-batata-frita-e-porcoes-peq-preto-500un-embalagem-food-truck.jpg",
                Ingredients = "Batata, óleo e sal a gosto.",
                Preparation = "Teste",

                },

                new ReceitasViewModel(){

                Id = 2,
                Title = "Pizza",
                Description = "Tudo sempre termina em pizza então por que não?",
                ImageUrl = "https://i.huffpost.com/gen/985357/original.jpg",
                Ingredients = "1 xícara (chá) de leite 1 ovo 1 colher (chá) de sal 1 colher (chá) de açúcar 1 colher (sopa) de margarina 1 e 1/2 xícara (chá) de farinha de trigo 1 colher (sobremesa) de fermento em pó 1/2 lata de molho de tomate",
                Preparation = "Teste2",

                }

            });

        }
        
        [Fact]
        public void Get_DeveResponderComReceitaSolicitada(){
            var receitasCadastradas = cadastrarReceitas();

            var context = CreateTestContext();

            context.AddRange(receitasCadastradas);
            context.SaveChanges();

            var controller = new ReceitasController(context);
            var receitas = controller.Get(2);

            receitas.Value.Should().BeEquivalentTo(new ReceitasViewModel(){   
                Id = 2,
                Title = "Pizza",
                Description = "Tudo sempre termina em pizza então por que não?",
                ImageUrl = "https://i.huffpost.com/gen/985357/original.jpg",
                Ingredients = "1 xícara (chá) de leite 1 ovo 1 colher (chá) de sal 1 colher (chá) de açúcar 1 colher (sopa) de margarina 1 e 1/2 xícara (chá) de farinha de trigo 1 colher (sobremesa) de fermento em pó 1/2 lata de molho de tomate",
                Preparation = "Teste2",
            }
            );

        }

        private Receita [] cadastrarReceitas(){
           return  new Receita[]{

                new Receita(){
                    Id = 1,
                    Titulo = "Batata frita",
                    Descricao = "Batata frita é aquele acompanhamento do qual todo mundo gosta e também é um aperitivo delicioso.",
                    UrlDaImagem = "https://img.elo7.com.br/product/original/1DEEFB7/caixinha-embalagem-batata-frita-e-porcoes-peq-preto-500un-embalagem-food-truck.jpg",
                    Ingredientes = "Batata, óleo e sal a gosto.",
                    Preparacao = "Teste",
                },
                new Receita(){
                    Id = 2,
                    Titulo = "Pizza",
                    Descricao = "Tudo sempre termina em pizza então por que não?",
                    UrlDaImagem = "https://i.huffpost.com/gen/985357/original.jpg",
                    Ingredientes = "1 xícara (chá) de leite 1 ovo 1 colher (chá) de sal 1 colher (chá) de açúcar 1 colher (sopa) de margarina 1 e 1/2 xícara (chá) de farinha de trigo 1 colher (sobremesa) de fermento em pó 1/2 lata de molho de tomate",
                    Preparacao = "Teste2",
                }
            };
        }

        [Fact]

        public void Insert_DeveInserirReceitaSolicitada()
        {
            var receitaViewModel = new ReceitasViewModel() {
                Title = "Testaaaaabhnnfyhthyte",
                Description ="Isso é um teste",
                Preparation="Coxinha",
                Ingredients="Teste1",
                ImageUrl= "urlimagem"
            };
            var context = CreateTestContext();
            var controller = new ReceitasController(context);

            var result = controller.Post(receitaViewModel);
            var receitaPost = result.Value;

            receitaPost
                .Should()
                .BeEquivalentTo(receitaViewModel, c => c.Excluding(r => r.Id));

            var receitaDoBanco = context.Receitas.FirstOrDefault(receita => receita.Id == receitaPost.Id);

            receitaDoBanco.Should().NotBeNull("Porque ela deve ser existente no banco de dados.");
        }

        [Fact]

        public void Insert_DeveLancarUmaExeption()
        {
            var receitaViewModel = new ReceitasViewModel() {
                Title = "Tesfzjsgfhzjsgfzkjas",
                Description ="Isso é um teste",
                Preparation="Coxinha",
                Ingredients="Teste1",
                ImageUrl= "urlimagem"
            };
            var context = CreateTestContext();
            var controller = new ReceitasController(context);

            Action act = () => controller.Post(receitaViewModel);
            act.Should().Throw<Exception>()
                .WithMessage("Erro");
        }

        [Fact]
        public void Put_DeveAtualizarInformacaoSolicitada()
        {

            var receitasCadastradas = cadastrarReceitas();

            var context = CreateTestContext();

            context.AddRange(receitasCadastradas);
            context.SaveChanges();

            var receitaViewModel = new ReceitasViewModel() {
                Title = "Tgas",
                Description ="Isso é um teste",
            };
            var controller = new ReceitasController(context);
            var result = controller.Put(2,receitaViewModel);

            var receitas = result.Value;

            receitas
                .Title
                .Should()
                .Be(receitaViewModel.Title);

            receitas
                .Description
                .Should()
                .Be(receitaViewModel.Description);
        }

         [Fact]

        public void Put_DeveLancarUmaExeption()
        {

            var receitasCadastradas = cadastrarReceitas();

            var context = CreateTestContext();

            context.AddRange(receitasCadastradas);
            context.SaveChanges();
            
            var receitaViewModel = new ReceitasViewModel() {
                Title = "Tesfzjsgfhzjsgffdszkjas",
                Description ="Isso é um teste",
                Preparation="Coxinha",
                Ingredients="Teste1",
                ImageUrl= "urlimagem"
            };
            var controller = new ReceitasController(context);

            Action act = () => controller.Put(2,receitaViewModel);
            act.Should().Throw<Exception>()
                .WithMessage("Erro");
        }
    }
}
