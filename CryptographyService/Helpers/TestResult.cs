using System.ComponentModel;

namespace CryptographyService.Helpers
{
    public enum TestResult
    {
        [Description("pomyślnie")]
        True,
        [Description("błędnie")]
        False,
        [Description("brak wyniku")]
        Default
    }
}
