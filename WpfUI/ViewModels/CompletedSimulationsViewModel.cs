using HunderedPrisonersProblemLibrary.Logic.Analysis.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Bases;
using WpfUI.Commands;
using WpfUI.Contexts.Abstractions;

namespace WpfUI.ViewModels
{
    public class CompletedSimulationsViewModel : BindableBase
    {
        private readonly IMultipleSimulationAnalyzer _multipleSimulationAnalyzer;

        public ISessionContext SessionContext { get; set; }

        private double _successRate;
        public double SuccessRate
        {
            get => _successRate;
            set 
            { 
                SetProperty(ref _successRate, value);
            }
        }



        public MyICommand ClearSimulationsCommand { get; set; }


        public CompletedSimulationsViewModel(ISessionContext sessionContext, IMultipleSimulationAnalyzer multipleSimulationAnalyzer)
        {
            SessionContext = sessionContext;
            _multipleSimulationAnalyzer = multipleSimulationAnalyzer;
            ClearSimulationsCommand = new MyICommand(ClearSimulations, CanClearSimulations);

            SessionContext.NewSimulationBatchCompleted += SessionContext_SimulationBatchChange;
            SessionContext.IsSimulatingChanged += (object? sender, EventArgs e) => ClearSimulationsCommand.RaiseCanExecuteChanged();
        }



        private void ClearSimulations()
        {
            SessionContext.Simulations.Clear();
            SessionContext.RaiseSimulationBatchChange();
        }

        private bool CanClearSimulations()
        {
            return SessionContext.IsSimulating == false;
        }



        private void SessionContext_SimulationBatchChange(object? sender, EventArgs e)
        {
            var simulationModels = App.Mapper.Map<List<Simulation>>(SessionContext.Simulations);

            SuccessRate = _multipleSimulationAnalyzer.GetSuccessRate(simulationModels);
        }
    }
}
