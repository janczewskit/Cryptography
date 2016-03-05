using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyService.Helpers.Tests
{
    [TestClass()]
    public class ByteExtensionsTests
    {
        [TestMethod()]
        public void GetBit()
        {
            byte testByte = 0x01;
            var firstActual = testByte.GetBit(0);
            var secondActual = testByte.GetBit(7);

            Assert.AreEqual(true, firstActual);
            Assert.AreEqual(false, secondActual);
        }
    }
}