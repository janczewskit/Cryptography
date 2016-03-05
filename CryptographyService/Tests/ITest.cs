using System.Collections.Generic;
using CryptographyService.Helpers;

namespace CryptographyService.Tests
{
    public interface ITest
    {
        TestResult Test(List<bool>[] testData);
    }
}