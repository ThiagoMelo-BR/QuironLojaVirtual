using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
