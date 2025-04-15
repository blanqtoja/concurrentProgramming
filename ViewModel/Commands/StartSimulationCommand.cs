using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Commands
{
    public class StartSimulationCommand : CommandBase
    {
        private MainViewModel _srcViewModel;
        public StartSimulationCommand(MainViewModel srcViewModel)
        {
            _srcViewModel = srcViewModel;
        }
        public override void Execute(object parameter)
        {
            _srcViewModel.StartSimulation(parameter);
        }
    }

}
