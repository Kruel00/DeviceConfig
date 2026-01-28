using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceTest.ViewModels
{
    public class HomeViewModel: ViewmodelBase
    {
        private readonly MainViewModel _mainViewModel;

        public RelayCommand<string> LogoutCommand { get; private set; }

        public HomeViewModel(MainViewModel main)
        {
            _mainViewModel = main;
            LogoutCommand = new RelayCommand<string>(_ => _mainViewModel.Logout());
        }


    }
}
