using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Cryptography.Models;
using Cryptography.ServiceProviders;
using CryptographyService.Helpers;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Win32;

namespace Cryptography.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region propeties

        private string _fileName;

        private List<bool>[] _loadedData;

        private ObservableCollection<ResultViewItem> _resultsView;

        public ObservableCollection<ResultViewItem> ResultsView
        {
            get { return _resultsView; }
            set
            {
                _resultsView = value;
                OnPropertyChanged(() => ResultsView);
            }
        }

        private ObservableCollection<string> _availableTestCollection;

        public ObservableCollection<string> AvailableTestCollection
        {
            get { return _availableTestCollection; }
            set
            {
                _availableTestCollection = value;
                OnPropertyChanged(() => AvailableTestCollection);
            }
        }

        private string _selectedTest;

        public string SelectedTest
        {
            get { return _selectedTest; }
            set
            {
                _selectedTest = value;
                OnPropertyChanged(() => SelectedTest);
            }
        }

        #endregion

        #region commands

        public ICommand ReadFileCommand { get; set; }
        public ICommand RunTestCommand { get; set; }
        #endregion

        public MainWindowViewModel()
        {
            ResultsView = new ObservableCollection<ResultViewItem>();
            ReadFileCommand = new DelegateCommand(ReadFileAction);
            RunTestCommand = new DelegateCommand(RunTestAction);
            LoadData();
        }

        private void LoadData()
        {
            AvailableTestCollection = CryptographyServiceProvider.GeAvailableTestsNames();
        }

        private void ReadFileAction()
        {
            var openFileDialog = new OpenFileDialog {Filter = "Pliki sbox (*.SBX)|*.SBX"};
            if (openFileDialog.ShowDialog() != true)
                return;
            if (!File.Exists(openFileDialog.FileName))
            {
                ResultsView.Add(new ResultViewItem("Podany plik nie istnieje"));
                return;
            }
            _fileName = openFileDialog.FileName;
            _loadedData = CryptographyServiceProvider.ReadSBoxes(_fileName);
        }

        private void RunTestAction()
        {
            if (_loadedData == null)
            {
                ResultsView.Add(new ResultViewItem("Najpierw musisz wczytać plik, który chcesz przetestować"));
                return;
            }
            var resultValue = CryptographyServiceProvider.RunTest(_selectedTest, _loadedData);
            PrintResult(resultValue);
        }

        private void PrintResult(TestResult resultValue)
        {
            if (string.IsNullOrEmpty(resultValue.ResultDescription))
            {
                ResultsView.Add(new ResultViewItem(string.Format("{0} zakończył się {1}",
                    _selectedTest, resultValue.Result.GetDescription()), resultValue.Result));
                return;
            }
            ResultsView.Add(new ResultViewItem(string.Format("{0} zakończył się {1}, a wyniki to {2}",
                _selectedTest, resultValue.Result.GetDescription(), resultValue.ResultDescription), resultValue.Result));
        }

        #region methods

        #endregion
    }
}
