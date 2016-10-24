using Quiron.LojaVirtual.Dominio.Repositório;
using Quiron.LojaVirtual.Web.Models;
using System.Linq;
using System.Web.Mvc;

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

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produto.OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produto.Count()
                }
            };

            return View(model);
        }
    }
}