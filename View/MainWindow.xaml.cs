using System.Windows;
using ViewModel;
using System.Windows.Input;

namespace View
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            //InitializeComponent();
            InitializeComponent();
            DataContext = new MainViewModel();

            Loaded += (s, e) =>
            {
                var vm = (MainViewModel)DataContext;
                vm.BallsAmount = 3;
                vm.Update();
            };
        }

    }
}
