using Microsoft.VisualStudio.TestTools.UnitTesting;
using OO_programming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_programming.Tests
{
    [TestClass()]
    public class PayCalculatorTests
    {
        //Create Unit test for PayCalculator
        
        //Create test method for GetGrossPayTest(),GetSuperAmount(),GetTaxAmount(),GetNetPay()
        [TestMethod()]
        public void GetGrossPayTest()
        {
            //set employee hour rate 25, worked hour 20 in assert1, 37 assert2
            Assert.AreEqual(500, PayCalculator.GetGrossPay(25.00, 20)); //Add the test data and expected results
            Assert.AreEqual(925, PayCalculator.GetGrossPay(25.00, 37));
            //after all test method completed, run the run
        }

        [TestMethod()]
        public void GetSuperAmount()
        {
            //set employee  gross pay 500 in assert1, 925 assert2
            Assert.AreEqual(52.5, PayCalculator.GetSuperAmount(500));
            Assert.AreEqual(97.125, PayCalculator.GetSuperAmount(925));
        }

        [TestMethod()]
        public void GetTaxAmount()
        {
            //set employee  gross pay 500, tax threshold ‘Y’ in assert1, ‘N’ assert2
            Assert.AreEqual(33.0929, PayCalculator.GetTaxAmount("Y",500));
            Assert.AreEqual(111.6171, PayCalculator.GetTaxAmount("N", 500));
        }

        [TestMethod()]
        public void GetNetPay()
        {
            //set employee  gross pay 500, tax amount 33.0929 in assert1, 111.6171 in assert2
            Assert.AreEqual(466.9071, PayCalculator.GetNetPay(33.0929, 500));
            Assert.AreEqual(388.3829, PayCalculator.GetNetPay(111.6171, 500));
        }


    }
}