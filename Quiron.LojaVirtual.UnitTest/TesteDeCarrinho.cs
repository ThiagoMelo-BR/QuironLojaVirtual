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

            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            Assert.AreEqual(itens.Length, 2);
        }

        //Teste de Adicionar Itens Existente ao Carrinho
        [TestMethod]
        public void AdicionarProdutosExistentesaoCarrinho()
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

            carrinho.AdicionarItemCarrinho(produto1, 1);

            carrinho.AdicionarItemCarrinho(produto2, 1);

            carrinho.AdicionarItemCarrinho(produto1, 10);

            ItemCarrinho[] resultado = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            Assert.AreEqual(resultado.Length, 2);

            Assert.AreEqual(resultado[0].Quantidade, 11);
        }

        //Teste de Remoção de itens no carrinho
        [TestMethod]
        public void RemoverItensCarrinho()
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

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItemCarrinho(produto1, 1);

            carrinho.AdicionarItemCarrinho(produto2, 3);

            carrinho.AdicionarItemCarrinho(produto3, 5);

            carrinho.AdicionarItemCarrinho(produto2, 1);

            carrinho.RemoverItemCarrinho(produto2);

            Assert.AreEqual(carrinho.ItensCarrinho.Where(p=> p.Produto.ProdutoId == produto2.ProdutoId).Count(), 0);

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);

        }

        //Teste do valor total
        [TestMethod]
        public void TestarValorTotal()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 10
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 20
                
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste 3",
                Preco = 30
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItemCarrinho(produto1, 1);
            //1 * 10 = 10 Total = 10

            carrinho.AdicionarItemCarrinho(produto2, 2);
            //2 * 20 = 40 Total = 50 

            carrinho.AdicionarItemCarrinho(produto3, 3);
            //3 * 30 = 90 Total 140

            Assert.AreEqual(carrinho.ObterValorTotalCarrinho(), 140);

        }

        //Teste de Limpar Carrinho
        [TestMethod]
        public void TesteDeLimparCarrinho()
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

            carrinho.LimparCarrinho();           

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
