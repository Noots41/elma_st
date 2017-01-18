using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = Calc;

namespace UnitTestProject1
{
    /// <summary>
    /// Тестирование Calc
    /// </summary>
    [TestClass]
    public class CalcUnitTest1
    {
        [TestMethod]
        public void SumTest()
        {
            var calc = new C.Calc(new C.IOperation[] { new C.SumOperation() });
            var result = (int)calc.Execute("Sum", new object[] { 1, 2 });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TripleTest()
        {
            var calc = new C.Calc(new C.IOperation[] { new C.TripleOperation() });
            var result = (int)calc.Execute("Triple",new object[] { 1, 2, 3 });
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void NullTest()
        {
            var calc = new C.Calc(new C.IOperation[] { new C.NullOperation() });
            var result = (int)calc.Execute("Null", new object[] { });
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void SingleTest()
        {
            var calc = new C.Calc(new C.IOperation[] { new C.SingleOperation() });
            var result = (int)calc.Execute("Single", new object[] { 3 });
            Assert.AreEqual(result, 9);
        }
    }
}
