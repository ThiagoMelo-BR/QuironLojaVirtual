using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using System.Linq;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteDeCarrinho
    {
        //Teste de Adicionar Itens ao Carrinho
        [TestMethod]
        public void AdicionarItensaoCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItemCarrinho(produto1, 12);

            carrinho.AdicionarItemCarrinho(produto2, 13);

            carrinho.AdicionarItemCarrinho(produto2, 25);

            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            Assert.AreEqual(itens.Length, 2);
        }
    }
}
