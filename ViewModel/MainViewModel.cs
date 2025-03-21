using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    //obsluga przelaczenstron w oknie
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new StartViewModel();
        }
    }
}
