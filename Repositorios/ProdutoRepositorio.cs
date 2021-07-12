using NetCore_WebApi_JWT_Swagger.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_WebApi_JWT_Swagger.Repositorios
{
    public class ProdutoRepositorio
    {
        private readonly List<Produto> ProdutosDb = new List<Produto>() {
            new Produto(){ Id = 1, Marca = "Sony", Nome = "PlayStation 5"},
            new Produto(){ Id = 2, Marca = "Microsoft", Nome = "Xbox Series X"},
            new Produto(){ Id = 3, Marca = "Nintendo", Nome = "Nintendo Switch"}

        };

        public List<Produto> GetProdutos() {
            return ProdutosDb.ToList();
        }

        public Produto GetProduto(int id)
        {
            return ProdutosDb.FirstOrDefault(x => x.Id == id);
        }

        public Produto AddProduto(Produto produto)
        {

            produto.Id = ProdutosDb.Max(x => x.Id) + 1;

            ProdutosDb.Add(produto);

            return produto;
        }

        public Produto UpdateProduto(Produto produto)
        {

            Produto bdProduto = ProdutosDb.FirstOrDefault(x => x.Id == produto.Id);

            if (bdProduto == null) return bdProduto;

            bdProduto = produto;

            return bdProduto;
        }

        public void DeleteProduto(int id) 
        {
            Produto ProdutoRemove = ProdutosDb.FirstOrDefault(x => x.Id == id);

            if(ProdutoRemove != null)
                ProdutosDb.Remove(ProdutoRemove);
        }

    }
}
