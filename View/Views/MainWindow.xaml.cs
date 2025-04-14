using System.Windows;
using ViewModel; // Import ViewModel
using System.Windows.Input;
using ViewModel.Stores;

namespace View.Views
{
    public partial class MainWindow : Window
    {
        private readonly StartViewModel _viewModel;
        private readonly GameStore _gameStore;

        public MainWindow(NavigationStore navigationStore)
        {
            InitializeComponent(); // Inicjalizacja UI

            _viewModel = new StartViewModel(_gameStore, navigationStore);
            DataContext = _viewModel; // Powiązanie z ViewModel
        }
    }
}
