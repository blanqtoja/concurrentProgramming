using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Stores;

namespace ViewModel.Commands
{
    public class StartCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly GameStore _gameStore;

        public StartCommand(GameStore gameStore, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _gameStore = gameStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new GameViewModel(_gameStore, new Model.BilliardGameModel());
        }
    }

}
