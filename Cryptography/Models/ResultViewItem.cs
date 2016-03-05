using CryptographyService.Helpers;

namespace Cryptography.Models
{
    public class ResultViewItem
    {
        public string Message { get; set; }
        public TestResult ResultValue { get; set; }

        public ResultViewItem(string message, TestResult resultValue = TestResult.Default)
        {
            Message = message;
            ResultValue = resultValue;
        }
    }
}