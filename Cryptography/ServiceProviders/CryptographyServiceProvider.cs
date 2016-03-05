using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CryptographyService;
using CryptographyService.Helpers;

namespace Cryptography.ServiceProviders
{
    public static class CryptographyServiceProvider
    {
        private static readonly ICryptographyService _instance;

        static CryptographyServiceProvider()
        {
                _instance = new Service();
        }

        public static List<bool>[] ReadSBoxes(string fileName) => _instance.ReadSBoxes(fileName);

        public static TestResult TestBalance(List<bool>[] data) => _instance.TestBalance(data);

        public static ObservableCollection<string> GeAvailableTestsNames() => _instance.GetAvailableTestNames();

        public static TestResult RunTest(string testName, List<bool>[] data) => _instance.RunTest(testName, data);
    }
}
