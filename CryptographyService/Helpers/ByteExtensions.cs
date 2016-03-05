
using System;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace CryptographyService.Helpers
{
    public static class ByteExtensions
    {
        private static readonly int _byteLength = 8;

        public static int Length(this byte Byte) => _byteLength;

        public static bool GetBit(this byte singleByte, int index)
        {
            if (index < 0 || index > 7)
                throw new ArgumentOutOfRangeException();
            
            var bitMask = (byte)(1 << index);
            var masked = (byte)(singleByte & bitMask);
            return masked != 0;
        }
    }
}
