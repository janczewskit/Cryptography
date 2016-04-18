using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using CryptographyService.Helpers;
using CryptographyService.Tests.Common;

namespace CryptographyService.Tests
{
    [DisplayName("Test sac")]
    public class SacTest : ITest
    {
        public TestResult Test(List<bool>[] testData)
        {
            var shuffles = GetShuffles(testData);
            var resultsForFunction = GetResultsForFunction(testData, shuffles);
            var results = SumResults(resultsForFunction);
            return new TestResult {Result = TestResultEnum.True,
                ResultDescription = (results.Sum(x => x) / 8).ToString(CultureInfo.CurrentCulture)
            };
        }

        private static IEnumerable<double> SumResults(List<double>[] resultsForFunction)
        {
            foreach (var item in resultsForFunction)
            {
                yield return item.Sum(x => x/8);
            }
        }

        private static List<double>[] GetResultsForFunction(List<bool>[] testData, List<List<bool>>[] shuffles)
        {
            var resultsForFunction = new List<double>[8];
            for (var i = 0; i < testData.Length; i++)
            {
                foreach (var item in shuffles[i])
                {
                    if (resultsForFunction[i] == null)
                        resultsForFunction[i] = new List<double>();
                    var intResult = (double) CommonTest.Xor(testData[i], item).Count(x => x);
                    resultsForFunction[i].Add(intResult/256);
                }
            }
            return resultsForFunction;
        }

        private static List<List<bool>>[] GetShuffles(List<bool>[] testData)
        {
            var shuffles = new List<List<bool>>[8];
            for (var i = 0; i < 8; i++)
            {
                for (var j = 1; j <= 8; j++)
                {
                    if (shuffles[i] == null)
                        shuffles[i] = new List<List<bool>>();
                    shuffles[i].Add(Shuffle(testData[i], j));
                }
            }
            return shuffles;
        }

        public static List<bool> Shuffle(List<bool> function, int jump)
        {
            var pairs = Pair.PreparePairs(function).ToList();
            for (int i = 0; i < function.Count; i++)
            {
                if (pairs[i].IsChanged)
                    continue;
                if (i + jump >= function.Count)
                    break;
                var tempValue = function[i + jump];
                pairs[i + jump].Value = function[i];
                pairs[i + jump].IsChanged = true;
                pairs[i].Value = tempValue;
                pairs[i].IsChanged = true;
            }
            return pairs.Select(x => x.Value).ToList();
        }
    }

    public class Pair
    {
        public bool Value { get; set; }
        public bool IsChanged { get; set; }

        public static IEnumerable<Pair> PreparePairs(List<bool> function)
        {
            foreach (var item in function)
            {
                yield return new Pair { Value = item, IsChanged = false };
            }
        }
    }
}
