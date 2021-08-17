using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase {

        // Lista estática de produtos
        public static List<Produto> produtos = new List<Produto>();

        public ProdutoController(){
            if (produtos.Count <= 0){
                Produto produto = new Produto() { 
                    Id = 1, Nome = "Tênis", Estoque = 10, Valor = 159.99 
                };
                produtos.Add(produto);
                
                produto = new Produto(){
                    Id= 2, Nome = "Camiseta", Estoque = 15, Valor = 89.78
                };
                produtos.Add(produto);

                produto = new Produto(){
                    Id= 3, Nome = "Boné", Estoque = 7, Valor = 55.45
                };
                produtos.Add(produto);
            }
         }

        // Método Get
        [HttpGet]
        public IActionResult Get(){            
            return Ok(produtos); // Retorna um resultado correto
        }

        // Método Get com filtro (ID)
        [HttpGet("{id}")]
        public IActionResult Get(int id){
            var produtoSelecionado = produtos.Where(
                prod => prod.Id == id );
            return Ok(produtoSelecionado);
        }

        // Método Post
        [HttpPost]
        public IActionResult Post([FromBody] Produto novoProduto){
            // Adicionar o produto na lista
            produtos.Add(novoProduto);
            // Retornar para o cliente o produto adicionado na lista
            return Created("", novoProduto);
        }

        // Método Put
        [HttpPut("{id}")]
        public string Put(int id){
            return $"Exemplo de Put com id = {id}";
        }

        // Método Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            // Verifica se existe um objeto com o ID igual ao ID passado como parâmetro
            if (produtos.Where(p => p.Id == id).Count() > 0){
                // Então foi encontrado um produto com o ID passado como parâmetro
                // Selecionar o produto que deverá ser removido
                Produto produtoSelecionado = produtos.Where(
                    p => p.Id == id).ToList()[0];
                // Remove o produto da lista
                produtos.Remove(produtoSelecionado);
                // Retorna um resultado para o cliente
                return NoContent();
            }
            return NotFound();
        }
    }
}