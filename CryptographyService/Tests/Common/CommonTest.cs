using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptographyService.Helpers;

namespace CryptographyService.Tests.Common
{
    public static class CommonTest
    {
        public static List<bool>[] GenerateLineFunctions()
        {
            var valueList = Enumerable.Range(0, 256).ToList();
            List<byte> byteList = new List<byte>();
            valueList.ForEach(x => byteList.Add((byte)x));
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

        public static List<bool> GetPlusOneFunction(List<bool> bools)
        {
            var result = new List<bool>();
            foreach (var item in bools)
            {
                result.Add(!item);
            }
            return result;
        }

        public static List<bool> Xor(List<bool> lineFunction, List<bool> secondLineFunction)
        {
            var result = new List<bool>();
            for (int i = 0; i < lineFunction.Count; i++)
            {
                result.Add(lineFunction[i] ^ secondLineFunction[i]);
            }
            
            return result;
        }
    }
}
