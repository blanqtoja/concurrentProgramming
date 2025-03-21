using System.Windows;
using ViewModel; // Import ViewModel
using System.Windows.Input;

namespace View.Views
{
    public partial class MainWindow : Window
    {
        private readonly StartViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent(); // Inicjalizacja UI

            _viewModel = new StartViewModel();
            DataContext = _viewModel; // Powiązanie z ViewModel
        }
    }
}
