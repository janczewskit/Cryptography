using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CryptographyService.Helpers;
using CryptographyService.Tests.Common;

namespace CryptographyService.Tests
{
    [DisplayName("Test nieliniowości")]
    public class OutlineTest : ITest
    {
        public TestResult Test(List<bool>[] testData)
        {
            var lineFunctions = CommonTest.GenerateLineFunctions();
            var combinedFunctions = GenerateCombinedFunctions(lineFunctions);
            var allFunctions = GetCombinedFunctionsPlusOne(combinedFunctions);

            var result = GetAllInlineTestValues(testData, allFunctions);
            result.Sort();

            return new TestResult {Result = TestResultEnum.True, ResultDescription = result.First().ToString()};
        }

        private List<int> GetAllInlineTestValues(List<bool>[] testData, List<List<bool>> allFunctions)
        {
            var result = new List<int>();
            foreach (var item in testData)
            {
                foreach (var combined in allFunctions)
                {
                    var xorSumOnes = CommonTest.Xor(item, combined).Count(x => x);
                    result.Add(xorSumOnes);
                }
            }
            return result;
        }

        private List<List<bool>> GetCombinedFunctionsPlusOne(Dictionary<string, List<bool>> combinedFunctions)
        {
            var allFunctions = combinedFunctions.Values.Where(x => x != null).ToList();
            combinedFunctions.Values.Where(x => x != null).ToList().ForEach(x => allFunctions.Add(CommonTest.GetPlusOneFunction(x)));
            return allFunctions;
        }

        private Dictionary<string, List<bool>> GenerateCombinedFunctions(List<bool>[] lineFunctions)
        {
            var valueList = Enumerable.Range(0, 256).ToList();
            List<byte> byteList = new List<byte>();
            valueList.ForEach(x => byteList.Add((byte) x));
            var combinedFunctions = new Dictionary<string, List<bool>>();
            for (int i = 0; i < valueList.Count; i++)
            {
                var value = XorDictionary(lineFunctions, byteList[i]);
                combinedFunctions.Add(value.Key, value.Value);
            }
            return combinedFunctions;
        }

        private KeyValuePair<string, List<bool>> XorDictionary(List<bool>[] lineFunctions, byte value)
        {
            List<bool> result = null;
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < 8; i++)
            {
                if (value.GetBit(i))
                {
                    if (result == null)
                    {
                        result = lineFunctions[i];
                        stringBuilder.Append(i + " ");
                        continue;
                    }
                    result = CommonTest.Xor(result, lineFunctions[i]);
                    stringBuilder.Append(i + " ");
                }
            }
            return new KeyValuePair<string, List<bool>>(stringBuilder.ToString(),result);
        }
    }
}
