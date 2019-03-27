using SwaggerWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwaggerWebAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        static readonly IProdutoRepositorio repositorio = new ProdutoRepositorio();

        /// <summary>
        /// Retorna todos os parametros valores
        /// </summary>
        public IEnumerable<Produto> GetAllProdutos()
        {
            return repositorio.GetAll();
        }
        /// <summary>
        /// Retorna todos os parametros valores
        /// </summary>
        public Produto GetProduto(int id)
        {
            Produto item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
    }
}
