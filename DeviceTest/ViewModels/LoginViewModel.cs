using System.Windows;

namespace DeviceTest.ViewModels;

public class LoginViewModel : ViewmodelBase
{
    private readonly MainViewModel? _mainViewModel;

    public string? Username { get; set; }
    public string? Password { get; set; } = string.Empty;
    public RelayCommand<string>? LoginCommand { get; private set; }

    public LoginViewModel(MainViewModel main)
    {
        _mainViewModel = main;
        LoginCommand = new RelayCommand<string>(Login);
    }

    private async void Login(string password)
    {
        var pwd = Password ?? string.Empty;

        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(pwd))
        {
            MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var token = await AuthService.LoginAsync(Username, pwd);

        if (token != null)
            _mainViewModel?.NavigateToHome();
        else
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
