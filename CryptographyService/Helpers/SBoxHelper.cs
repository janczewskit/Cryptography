using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyService.Helpers
{
    public class SBoxHelper
    {
        internal static List<bool>[] ReadSBoxBytes(byte[] optimizedBytes)
        {
            var sboxBytes = new List<bool>[8];
            for (var i = 0; i < optimizedBytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (sboxBytes[j] == null)
                        sboxBytes[j] = new List<bool>();
                    sboxBytes[j].Add(optimizedBytes[i].GetBit(j));
                }
            }
            return sboxBytes;
        }
    }
}
