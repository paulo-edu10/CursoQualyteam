using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cursonetcorequalyteam.Dominio;
using cursonetcorequalyteam.Infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace cursonetcorequalyteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {

        private readonly ReceitasContext _context;

        public ReceitasController(ReceitasContext context){
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ReceitasViewModel>> Get()
        {
        
           return  _context.Receitas
           .Select( Receita=> new ReceitasViewModel(){
                Id = Receita.Id,
                Description = Receita.Descricao,
                ImageUrl = Receita.UrlDaImagem,
                Ingredients = Receita.Ingredientes,
                Preparation = Receita.Preparacao,
                Title = Receita.Titulo,
            }
            ).ToArray();   

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ReceitasViewModel> Get(int id)
        {
            return _context.Receitas.Select( Receita=> new ReceitasViewModel(){
                Id = Receita.Id,
                Description = Receita.Descricao,
                ImageUrl = Receita.UrlDaImagem,
                Ingredients = Receita.Ingredientes,
                Preparation = Receita.Preparacao,
                Title = Receita.Titulo,
            }).FirstOrDefault(receita=> receita.Id == id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<ReceitasViewModel> Post([FromBody] ReceitasViewModel receitaPayLoad)
        {

            var receita = new Receita(
                receitaPayLoad.Title,
                receitaPayLoad.Description,
                receitaPayLoad.Ingredients,
                receitaPayLoad.Preparation,
                receitaPayLoad.ImageUrl
            );
            _context.Receitas.Add(receita);
            _context.SaveChanges();

            var newViewModel = new ReceitasViewModel(receita.Id,receita.Titulo, receita.Descricao, receita.Ingredientes,receita.Preparacao, receita.UrlDaImagem);

            return newViewModel;

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public  ActionResult<ReceitasViewModel> Put(int id, [FromBody] ReceitasViewModel viewModel)
        {
            var receita = _context.Receitas.FirstOrDefault(item => item.Id == id);

            receita.Update(viewModel.Title,viewModel.Description);

            _context.SaveChanges();

            var newViewModel = new ReceitasViewModel(receita.Id,receita.Titulo, receita.Descricao, receita.Ingredientes,receita.Preparacao, receita.UrlDaImagem);

            return newViewModel;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class ReceitasViewModel{

        public ReceitasViewModel(){}
        public ReceitasViewModel(int id, string title, string description, string ingredients, string preparation, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Ingredients = ingredients;
            Preparation = preparation;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string  Ingredients { get; set; }
        public string Preparation { get; set; }
        public string  ImageUrl { get; set; }
    }
}
