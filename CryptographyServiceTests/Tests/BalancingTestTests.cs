using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CryptographyService.Helpers;

namespace CryptographyService.Tests.Tests
{
    [TestClass]
    public class BalancingTestTests
    {
        [TestMethod]
        public void Test()
        {
            var ballancingTest = new BalancingTest();
            var testCollectionFalse = new List<bool>[1];
            testCollectionFalse[0] = new List<bool> {true,true,true,false,true};
            Assert.AreEqual(TestResult.False, ballancingTest.Test(testCollectionFalse));

            var testCollectionTrue = new List<bool>[1];
            testCollectionTrue[0] = new List<bool> { true, false, true, false };
            Assert.AreEqual(TestResult.True, ballancingTest.Test(testCollectionTrue));
        }
    }
}