using System.Collections.Generic;
using System.Linq;
using Loja.API.Data;
using Loja.API.Models;

namespace Loja.API.Services {
    public class ProdutoService : IProdutoService {
        private readonly DataContext _context;
        public ProdutoService(DataContext context) {
            this._context = context;            
        }
        // Implementação dos métodos abstratos declarados na Interface
        public IEnumerable<Produto> Buscar(){
            var produtos = _context.Produtos;
            if (produtos == null || produtos.ToList().Count == 0)//{
                return null;
            //} else {
                return produtos;
            //}            
        }
        public Produto BuscarPorId(int id){
            var produto = _context.Produtos.FirstOrDefault(
                p => p.Id == id
            );
            return produto;
        }
        public IEnumerable<Produto> BuscarPorNome(string nome){
            var produtos = _context.Produtos.Where(
                p => p.Nome.Contains(nome)
            );
            if (produtos == null || produtos.ToList().Count == 0)
                return null;
            return produtos;
        }
        //public IEnumerable<Produto> OrdenarProdutos(string ordenaPor, string crescenteOuDescrescente){ }
        public Produto Adicionar(Produto novoProduto){
            var produto = new Produto(novoProduto.Nome, novoProduto.Estoque, novoProduto.Valor);
            // Adicionar o produto criado no contexto do EF
            _context.Add(produto);
            // Salvar na tabela do BD o produto que foi adicionado no contexto do EF
            _context.SaveChanges();
            return produto;
        }
        public Produto Atualizar(int id, Produto produtoAtualizado){
            // Retorna o produto da tabela do BD
            var produto = _context.Produtos.FirstOrDefault(
                prod => prod.Id == id
            );
            // Verifica se não retornou nenhum produto
            if (produto == null)
                return null;
            // Atualizar o produto no contexto do EF
            _context.Update(produto);
            // Salva as alterações do produto na tabela do BD
            _context.SaveChanges();
            return produto;
        }
        public bool Remover(int id){
            var produto = _context.Produtos.FirstOrDefault(
                p => p.Id == id
            );
            if (produto == null) 
                return false;
            // Remover o produto do contexto do EF
            _context.Remove(produto);
            // Remover o produto a tabela do BD
            _context.SaveChanges();
            return true;
        }

    }
}