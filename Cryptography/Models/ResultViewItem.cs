using CryptographyService.Helpers;

namespace Cryptography.Models
{
    public class ResultViewItem
    {
        public string Message { get; set; }
        public TestResultEnum ResultValue { get; set; }

        public ResultViewItem(string message, TestResultEnum resultValue = TestResultEnum.Default)
        {
            Message = message;
            ResultValue = resultValue;
        }
    }
}