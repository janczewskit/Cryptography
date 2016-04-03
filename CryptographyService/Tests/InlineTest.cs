using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptographyService.Helpers;

namespace CryptographyService.Tests
{
    [DisplayName("Test nieliniowości")]
    public class InlineTest : ITest
    {
        public TestResult Test(List<bool>[] testData)
        {
            var lineFunctions = GenerateLineFunctions();
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
                    var xorSumOnes = Xor(item, combined).Count(x => x);
                    var xorSumZeros = Xor(item, combined).Count(x => !x);
                    result.Add(xorSumOnes);
                    result.Add(xorSumZeros);
                }
            }
            return result;
        }

        private List<List<bool>> GetCombinedFunctionsPlusOne(Dictionary<string, List<bool>> combinedFunctions)
        {
            var allFunctions = combinedFunctions.Values.Where(x => x != null).ToList();
            combinedFunctions.Values.Where(x => x != null).ToList().ForEach(x => allFunctions.Add(GetPlusOneFunction(x)));
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

        private List<bool> GetPlusOneFunction(List<bool> bools)
        {
            var result = new List<bool>();
            foreach (var item in bools)
            {
                result.Add(item != true ? false : true);
            }
            return result;
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
                    result = Xor(result, lineFunctions[i]);
                    stringBuilder.Append(i + " ");
                }
            }
            return new KeyValuePair<string, List<bool>>(stringBuilder.ToString(),result);
        }
        
        private List<bool> Xor(List<bool> lineFunction, List<bool> secondLineFunction)
        {
            var result = new List<bool>();
            for (int i = 0; i < lineFunction.Count; i++)
            {
                result.Add(lineFunction[i] ^ secondLineFunction[i]);
            }

            return result;
        }

        private static List<bool>[] GenerateLineFunctions()
        {
            var valueList = Enumerable.Range(0, 256).ToList();
            List<byte> byteList = new List<byte>();
            valueList.ForEach(x => byteList.Add((byte) x));
            var lineFunctions = new List<bool>[8];
            for (int i = 0; i < 8; i++)
            {
                foreach (var item in byteList)
                {
                    if (lineFunctions[i] == null)
                        lineFunctions[i] = new List<bool>();
                    lineFunctions[i].Add(item.GetBit(i));
                }
            }
            return lineFunctions;
        }
    }
}
