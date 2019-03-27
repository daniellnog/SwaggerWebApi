using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SwaggerWebAPI.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();

        private int _nextId = 1;

        public ProdutoRepositorio()
        {
            Produto p = new Produto { Nome = "Guaraná Antartica", Categoria = "Refrigerantes", Preco = 4.59M  };
            produtos.Add(p);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public Produto Get(int id)
        {
            return produtos.Find(p => p.Id == id);
        }
    }
}