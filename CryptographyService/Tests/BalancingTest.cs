﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CryptographyService.Helpers;

namespace CryptographyService.Tests
{
    [DisplayName("Test zbalansowania")]
    public class BalancingTest: ITest
    {
        public TestResult Test(List<bool>[] testData)
        {
            foreach (var testList in testData)
            {
                var result = testList.Count(x => x);
                if (result == (double)testList.Count() / 2)
                    continue;
                return new TestResult {Result = TestResultEnum.False};
            }
            return new TestResult { Result = TestResultEnum.True};
        }
    }
}
