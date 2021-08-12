using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CalculatorChallenge
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddMethod()
        {
            Calculator calculator = new Calculator();
            List<decimal> number = new List<decimal> { 1, 3, 3,3.5m,8.5m,0.245m,18.458m };
            calculator.Add(number);
            calculator.Multiply(number);
            calculator.Average(number);
            calculator.Divide(4, 4);
        //    Assert.AreEqual(7, calculator.Add(number));
        //    Assert.AreEqual(9, calculator.Multiply(number));
        }
    }
}
