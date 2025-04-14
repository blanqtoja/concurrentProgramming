using System.Configuration;
using System.Data;
using System.Windows;
using ViewModel.Stores;

namespace View;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly NavigationStore _navigationStore;
    private readonly GameStore _gameStore;


    public App()
    {
         _navigationStore = new NavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _navigationStore.CurrentViewModel = new ViewModel.StartViewModel(_gameStore, _navigationStore);

        MainWindow = new Views.MainWindow(_navigationStore)
        {
            DataContext = new ViewModel.MainViewModel(_navigationStore)
        };
        MainWindow.Show();

        base.OnStartup(e);
        
    }
}

