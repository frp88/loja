using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase {
        public ProdutoController(){ }

        // Método Get
        [HttpGet]
        public string Get(){
            return "Retorno de todos os produtos";
        }

        // Método Get com filtro (ID)
        [HttpGet("{id}")]
        public string Get(int id){
            return "Retorno do produto com id = " + id;
        }

        // Método Post
        [HttpPost]
        public string Post(){
            return "Exemplo de Post";
        }

        // Método Put
        [HttpPut("{id}")]
        public string Put(int id){
            return $"Exemplo de Put com id = {id}";
        }

        // Método Delete
        [HttpDelete("{id}")]
        public string Delete(int id){
            return $"Exemplo de Delete com id = {id}";
        }
    }
}