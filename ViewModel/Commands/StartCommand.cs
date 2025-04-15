using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace ViewModel.Commands
{
    public class StartCommand : CommandBase
    {
        private MainViewModel _srcViewModel;
        public StartCommand(MainViewModel srcViewModel)
        {
            _srcViewModel = srcViewModel;
        }
        public override void Execute(object parameter)
        {
            // wystartowanie symulacji
            int i = 0;
            _srcViewModel.Update();

            //_navigationStore.CurrentViewModel = new GameViewModel(_gameStore, new Model.BilliardGameModel());
        }
    }

}
