using System.Configuration;
using System.Data;
using System.Windows;

namespace View;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new Views.MainWindow()
        {
            DataContext = new ViewModel.StartViewModel()
        };
        MainWindow.Show();

        base.OnStartup(e);
        
    }
}

