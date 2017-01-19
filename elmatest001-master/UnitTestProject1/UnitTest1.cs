using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = Calc;

namespace UnitTestProject1
{
    /// <summary>
    /// тестирование Calc
    /// </summary>
    [TestClass]
    public class CalcUnitTest
    {
        [TestMethod]
        public void SumTest()
        {
            var calc = new C.Calc();
            var result = calc.Sum(1, 2);
            Assert.AreEqual(result, 3);
        }
    }
}
