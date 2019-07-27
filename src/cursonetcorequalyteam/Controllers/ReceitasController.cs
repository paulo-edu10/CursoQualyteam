using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace cursonetcorequalyteam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ReceitasViewModel>> Get()
        {
         return  new ReceitasViewModel[]{

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
        };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class ReceitasViewModel{
        public int Id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public string  Ingredients { get; set; }
        public string Preparation { get; set; }
        public string  ImageUrl { get; set; }
    }
}
