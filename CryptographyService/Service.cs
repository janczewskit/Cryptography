using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using CryptographyService.DataOperations;
using CryptographyService.Helpers;
using CryptographyService.Tests;

namespace CryptographyService
{
    public class Service : ICryptographyService
    {
        public List<bool>[] ReadSBoxes(string fileName)
        {
            var optymizedBytes = FileManager.ReadFileAndOptimizeBytes(fileName);
            return SBoxHelper.ReadSBoxBytes(optymizedBytes);
        }

        public TestResult TestBalance(List<bool>[] data)
        {
            var balancingTest = new BalancingTest();
            return balancingTest.Test(data);
        }

        public ObservableCollection<string> GetAvailableTestNames()
        {
            var testsClasses = GetTestClasses();
            var tests = testsClasses.SelectMany(x => x.GetCustomAttributesData());
            return new ObservableCollection<string>(tests
                .Select(x => x.ConstructorArguments.First().Value.ToString()));
        }

        public TestResult RunTest(string testName, List<bool>[] data)
        {
            var testClasses = GetTestClasses();
            var testType = testClasses.FirstOrDefault(x => x.GetCustomAttributesData()
                .Any(y => y.ConstructorArguments.First().Value.ToString() == testName));

            if (testType == null)
                throw new Exception("Test o podanej nazwie nie istnieje");

            var testClass = Activator.CreateInstance(testType);
            if(!(testClass is ITest))
                throw  new Exception("Odnaleziona klasa nie spełnia warunków klasy testującej");

            return (testClass as ITest).Test(data);
        }

        private IEnumerable<Type> GetTestClasses()
        {
            var type = typeof(ITest);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);
        }
    }
}
