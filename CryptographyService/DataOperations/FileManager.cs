using System.IO;
using System.Linq;

namespace CryptographyService.DataOperations
{
    public class FileManager
    {
        internal static byte[] ReadBytes(string fileName) => File.ReadAllBytes(fileName);

        internal static byte[] ConvertToOptimizedBytes(byte[] bytes) => bytes.Where(item => item != byte.MinValue).ToArray();

        internal static byte[] ReadFileAndOptimizeBytes(string fileName)
        {
            var bytes = ReadBytes(fileName);
            return ConvertToOptimizedBytes(bytes);
        }
    }
}
