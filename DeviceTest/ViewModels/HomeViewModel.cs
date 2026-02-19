using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceTest.ViewModels
{
    public class HomeViewModel: ViewmodelBase
    {
        private readonly MainViewModel _mainViewModel;

        private string _viewName;

        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }

        public RelayCommand<string> LogoutCommand { get; private set; }
        public RelayCommand<string> NavigateToViewCommand { get; private set; }

        public HomeViewModel(MainViewModel main)
        {
            _mainViewModel = main;
            LogoutCommand = new RelayCommand<string>(_ => _mainViewModel.Logout());
            NavigateToViewCommand = new RelayCommand<string>(UpdateViewName);
        }

        public void UpdateViewName(object parameter)
        {
            _mainViewModel.NavigateToView(parameter.ToString() ?? string.Empty);
        }
    }
}
