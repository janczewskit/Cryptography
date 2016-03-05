using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using CryptographyService;
using CryptographyService.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptographyService.Tests
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void GetAvailableTestNames()
        {
            var tests = new Service().GetAvailableTestNames();
            Assert.IsTrue(tests.Any(x => x == "Test zbalansowania"));
        }
    }
}
