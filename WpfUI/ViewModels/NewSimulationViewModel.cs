using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.SimulationLogic.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System.Collections.ObjectModel;
using WpfUI.Bases;
using WpfUI.Commands;
using WpfUI.Contexts.Abstractions;
using WpfUI.Models;

namespace WpfUI.ViewModels
{
    public class NewSimulationViewModel : BindableBase
    {
        private readonly ISimulationFactory _simulationFactory;
        private readonly ISimulationExecutor _simulationExecutor;

        private ISessionContext _sessionContext;
        public ISessionContext SessionContext
        {
            get => _sessionContext;
            set => SetProperty(ref _sessionContext, value);
        }


        private int _simulationQuantity = 100;
        public int SimulationQuantity
        {
            get => _simulationQuantity;
            set 
            { 
                SetProperty(ref _simulationQuantity, value);
                RunSimulationCommand.RaiseCanExecuteChanged();
            }
        }

        private int _prisonerQuantity = 100;
        public int PrisonerQuantity
        {
            get => _prisonerQuantity;
            set
            {
                SetProperty(ref _prisonerQuantity, value);
                RunSimulationCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<Strategy> _prisonerStrategies;
        public ObservableCollection<Strategy> PrisonerStrategies
        {
            get => _prisonerStrategies;
            set
            {
                SetProperty(ref _prisonerStrategies, value);
            }
        }

        private Strategy? _selectedStrategy;
        public Strategy? SelectedStrategy
        {
            get => _selectedStrategy;
            set 
            { 
                SetProperty(ref _selectedStrategy, value);
                RunSimulationCommand.RaiseCanExecuteChanged();
            }
        }



        public MyAsyncICommand RunSimulationCommand { get; set; }



        public NewSimulationViewModel(ISessionContext sessionContext,
                                      ISimulationFactory simulationFactory,
                                      ISimulationExecutor simulationExecutor)
        {
            _sessionContext = sessionContext;
            _simulationFactory = simulationFactory;
            _simulationExecutor = simulationExecutor;

            _prisonerStrategies = 
                new ObservableCollection<Strategy>(
                    Enum.GetValues(typeof(Strategy)).Cast<Strategy>());

            RunSimulationCommand = new MyAsyncICommand(RunSimulationsAsync, CanRunSimulations);
            SessionContext.IsSimulatingChanged += (object? sender, EventArgs e) => RunSimulationCommand.RaiseCanExecuteChanged();
        }



        private async Task RunSimulationsAsync()
        {
            var simulations = _simulationFactory.CreateSimulations(SimulationQuantity, PrisonerQuantity);

            if (SelectedStrategy is Strategy selectedStrategy)
            {
                SessionContext.IsSimulating = true;


                _simulationExecutor.SetStrategyToUse(selectedStrategy);

                var simulationTasks = simulations.Select(simulation => Task.Run(async () =>
                {
                    await _simulationExecutor.ExecuteSimulationAsync(simulation);

                    return App.Mapper.Map<SimulationModel>(simulation);
                }));

                var completedSimulations = await Task.WhenAll(simulationTasks);

                foreach (var simulation in completedSimulations)
                {
                    SessionContext.Simulations.Add(simulation);
                }

                SessionContext.RaiseSimulationBatchChange();
                SessionContext.IsSimulating = false;
            }
        }

        private bool CanRunSimulations()
        {
            return SimulationQuantity > 0 && 
                   PrisonerQuantity > 0 && 
                   SelectedStrategy != null &&
                   SessionContext.IsSimulating == false;
        }
    }
}
