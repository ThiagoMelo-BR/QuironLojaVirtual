using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositório;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoRepositorio _repositorio;
        // GET: Produto
        public ActionResult Index()
        {
            _repositorio = new ProdutoRepositorio();
            var produtos = _repositorio.Produto.Take(10);

            return View(produtos);
        }
    }
}