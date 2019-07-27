using System;
using Xunit;
using FluentAssertions;
using cursonetcorequalyteam.Controllers;

namespace CursoNetCoreQualyteam.Controllers.Tests
{
    public class ReceitasControllerTests
    {
        [Fact]
        public void Get_DeveResponderComTodasAsReceitasCadastradas()
        {
            var controller = new ReceitasController();
            var receitas = controller.Get();

            receitas.Value.Should().BeEquivalentTo(new ReceitasViewModel[]{

                new ReceitasViewModel(){

                Id = 1,
                title = "Batata frita",
                Description = "Batata frita é aquele acompanhamento do qual todo mundo gosta e também é um aperitivo delicioso.",
                ImageUrl = "https://img.elo7.com.br/product/original/1DEEFB7/caixinha-embalagem-batata-frita-e-porcoes-peq-preto-500un-embalagem-food-truck.jpg",
                Ingredients = "Batata, óleo e sal a gosto.",
                Preparation = "Teste",

                },

                new ReceitasViewModel(){

                Id = 2,
                title = "Pizza",
                Description = "Tudo sempre termina em pizza então por que não?",
                ImageUrl = "https://i.huffpost.com/gen/985357/original.jpg",
                Ingredients = "1 xícara (chá) de leite 1 ovo 1 colher (chá) de sal 1 colher (chá) de açúcar 1 colher (sopa) de margarina 1 e 1/2 xícara (chá) de farinha de trigo 1 colher (sobremesa) de fermento em pó 1/2 lata de molho de tomate",
                Preparation = "Teste2",

                }

            });

        }
    }
}
