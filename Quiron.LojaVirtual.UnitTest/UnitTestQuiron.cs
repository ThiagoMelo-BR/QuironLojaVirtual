using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Web.HtmlHelpers;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestQuiron
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Take()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var resultado = from num in numeros.Take(5) select num;
            int[] teste = { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void Skip()
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var resultado = from num in numeros.Take(5).Skip(2) select num;
            int[] teste = { 3, 4, 5 };
            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void TestarPaginacao()
        {
            //Arrange
            HtmlHelper html = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>" +
                @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>" +
                @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString());
        }
    }
}
