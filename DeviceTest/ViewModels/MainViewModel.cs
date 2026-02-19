
namespace DeviceTest.ViewModels
{
    public class MainViewModel: ViewmodelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public MainViewModel()
        {
            ShowLogin();
        }

        public void ShowLogin()
        {
            CurrentView = new HomeViewModel(this);
            OnPropertyChanged(nameof(CurrentView));
        }

        public void NavigateToHome()
        {
            CurrentView = new HomeViewModel(this);
        }
        //public void ShowSettings()
        //{
        //    CurrentView = new SettingsViewModel(this);
        //    OnPropertyChanged(nameof(CurrentView));
        //}

        public void ShowItems()
        {
            CurrentView = new ItemsViewModel(this);
            OnPropertyChanged(nameof(CurrentView));
        }

        public void Logout()
        {
            AuthService.Logout();
            CurrentView = new LoginViewModel(this);
        }


        public void NavigateToView(string viewName)
        {
            switch (viewName)
            {
                case "Home":
                    NavigateToHome();
                    break;
                case "Settings":
                    //ShowSettings();
                    break;
                case "Items":
                    ShowItems();
                    break;
                default:
                    break;
            }
        }
    }
}
