using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itenscarrinho = new List<ItemCarrinho>();
        //Adicionar
        public void AdicionarItemCarrinho(Produto produto, decimal quantidade)
        {
            //Verifica se o item está inserido na lista, se não tiver devolve um objeto do tipo produto null
            ItemCarrinho item = _itenscarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if(item == null)
            {
                _itenscarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }
        //Remover item
        public void RemoverItemCarrinho(Produto produto)
        {
            _itenscarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }
        //Limpar o carrinho
        public void LimparCarrinho()
        {
            _itenscarrinho.Clear();
        }        
        //ObterValorTotal
        public Decimal ObterValorTotalCarrinho()
        {
            return _itenscarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }
        //Itens do carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itenscarrinho; }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public decimal Quantidade { get; set; } 

    }

}
