using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositório;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Web.Models;



namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutoRepositorio _repositorio;
        // GET: Carrinho
        public RedirectToRouteResult Adicionar(int produtoid, string returnUrl)
        {
            _repositorio = new ProdutoRepositorio();

            Produto produto = _repositorio.Produto.FirstOrDefault(p => p.ProdutoId == produtoid);

            if(produto != null)
            {
                ObterCarrinho().AdicionarItemCarrinho(produto, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Session"];

            if(carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Session"] = carrinho;
            }

            return carrinho;
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutoRepositorio();

            Produto produto = _repositorio.Produto.FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                ObterCarrinho().RemoverItemCarrinho(produto);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturUrl = returnUrl
            });
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }
    }
}