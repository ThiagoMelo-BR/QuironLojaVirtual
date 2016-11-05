using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositório;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        private ProdutoRepositorio _repositorio;

        public PartialViewResult Menu(string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;
            _repositorio = new ProdutoRepositorio();

            IEnumerable<string> categorias = _repositorio.Produto.Select(p => p.Categoria)
                .Distinct()
                .OrderBy(p => p);

            return PartialView(categorias);
        }
    }
}