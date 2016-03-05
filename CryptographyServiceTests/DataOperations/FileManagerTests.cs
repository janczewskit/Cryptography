using System.Linq;
using CryptographyService.DataOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptographyService.DataOperations.Tests
{
    [TestClass]
    public class FileManagerTests
    {
        //"c:\\users\\tomek\\documents\\visual studio 2015\\Projects\\Cryptography\\CryptographyService\\sbox_08x08_20130109_220643_01.SBX");

        [TestMethod]
        public void ConvertToOptimizedBytes()
        {
            var testBytes = new byte[] { 255, 1, 0, 2, 0, 3 };
            var expectedBytes = new byte[] { 255, 1, 2, 3 };
            byte[] actualBytes = FileManager.ConvertToOptimizedBytes(testBytes);
            for (int i = 0; i < actualBytes.Length; i++)
            {
                Assert.AreEqual(expectedBytes[i], actualBytes[i]);
            }
        }
    }
}