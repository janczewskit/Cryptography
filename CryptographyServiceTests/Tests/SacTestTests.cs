using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyService.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyService.Tests.Tests
{
    [TestClass]
    public class SacTestTests
    {
        [TestMethod]
        public void Test()
        {
            var sacTest = new SacTest();
            sacTest.Test(new List<bool>[8]);
            Assert.IsTrue(true);
        }
    }
}