using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositório;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        public int ProdutosPorPagina = 3;
        private ProdutoRepositorio _repositorio;
        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutoRepositorio();

            var produtos = _repositorio.Produto.OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina);

            return View(produtos);
        }
    }
}