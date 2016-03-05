using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptographyService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptographyService.DataOperations;

namespace CryptographyService.Helpers.Tests
{
    [TestClass()]
    public class SBoxHelperTests
    {

        [TestMethod]
        public void ReadSBoxBytes()
        {
            var testBytes = new byte[] { 255, 0, 255 };
            var result = SBoxHelper.ReadSBoxBytes(testBytes);
            Assert.IsTrue(result[0].ElementAt(0) == result[1].ElementAt(0) == result[2].ElementAt(0) == result[3].ElementAt(0) == result[4].ElementAt(0) == result[5].ElementAt(0) == result[6].ElementAt(0) == result[7].ElementAt(0));
            Assert.IsTrue(result[0].ElementAt(1) == result[1].ElementAt(1) == result[2].ElementAt(1) == result[3].ElementAt(1) == result[4].ElementAt(1) == result[5].ElementAt(1) == result[6].ElementAt(1) == result[7].ElementAt(1));
        }
    }
}