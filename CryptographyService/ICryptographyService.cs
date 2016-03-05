using System.Collections.Generic;
using System.Collections.ObjectModel;
using CryptographyService.Helpers;

namespace CryptographyService
{
    public interface ICryptographyService
    {
        List<bool>[] ReadSBoxes(string fileName);
        TestResult TestBalance(List<bool>[] data);
        ObservableCollection<string> GetAvailableTestNames();
        TestResult RunTest(string testName, List<bool>[] data);
    }
}