using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Storages;

namespace ViewModel.Commands
{
    public class StartCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public StartCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new GameViewModel();
        }
    }

}
