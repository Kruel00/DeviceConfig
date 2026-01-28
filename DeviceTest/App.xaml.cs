using System.Configuration;
using System.Data;
using System.Runtime.Serialization.DataContracts;
using System.Security.Authentication.ExtendedProtection;
using System.Windows;
using DeviceTest.Views;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceTest;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    //protected override void OnStartup(StartupEventArgs e)
    //{
    //    base.OnStartup(e);

    //    var loginWindow = new LoginWindow();
    //    bool? result = loginWindow.ShowDialog();

    //    if (result == true)
    //        new MainWindow().Show();
    //    else
    //        Shutdown();
    //}   
}

