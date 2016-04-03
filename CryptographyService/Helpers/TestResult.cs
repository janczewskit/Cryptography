using System;
using System.ComponentModel;

namespace CryptographyService.Helpers
{
    public class TestResult
    {
        public string ResultDescription { get; set; }
        public TestResultEnum Result { get; set; }

        public override bool Equals(object obj)
        {
            var other = (TestResult) obj;
            return Result == other.Result;
        }
        
    }

    public enum TestResultEnum
    {
        [Description("pomyślnie")]
        True,
        [Description("błędnie")]
        False,
        [Description("brak wyniku")]
        Default
    }
}
