using Quiron.LojaVirtual.Dominio.Repositório;
using Quiron.LojaVirtual.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        public int ProdutosPorPagina = 5;

        private ProdutoRepositorio _repositorio;
        // GET: Vitrine
        public ActionResult ListaProdutos(string categoria, int pagina = 1)
        {
            _repositorio = new ProdutoRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = _repositorio.Produto
                 .Where(p => categoria == null || p.Categoria.TrimEnd() == categoria)
                 .OrderBy(p => p.Descricao)
                 .Skip((pagina - 1) * ProdutosPorPagina)
                 .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produto                   
                    .Where(p => categoria == null || p.Categoria.TrimEnd() == categoria)
                    .Count()
                },

                CategoriaAtual = categoria          
                
            };

            return View(model);
        }
    }
}