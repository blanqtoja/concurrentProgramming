using System.Configuration;
using System.Data;
using System.Windows;
using ViewModel.Storages;

namespace View;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly NavigationStore _navigationStore;

    public App()
    {
         _navigationStore = new NavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _navigationStore.CurrentViewModel = new ViewModel.StartViewModel();

        MainWindow = new Views.MainWindow()
        {
            DataContext = new ViewModel.MainViewModel(_navigationStore)
        };
        MainWindow.Show();

        base.OnStartup(e);
        
    }
}

