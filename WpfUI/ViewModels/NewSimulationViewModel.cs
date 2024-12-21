using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
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
        private readonly IPrisonerSimulationFactory _simulationFactory;
        private readonly IPrisonerSimulationExecutor _simulationExecutor;

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

        private ObservableCollection<PrisonerStrategy> _prisonerStrategies;
        public ObservableCollection<PrisonerStrategy> PrisonerStrategies
        {
            get => _prisonerStrategies;
            set
            {
                SetProperty(ref _prisonerStrategies, value);
            }
        }

        private PrisonerStrategy? _selectedPrisonerStrategy;
        public PrisonerStrategy? SelectedPrisonerStrategy
        {
            get => _selectedPrisonerStrategy;
            set 
            { 
                SetProperty(ref _selectedPrisonerStrategy, value);
                RunSimulationCommand.RaiseCanExecuteChanged();
            }
        }



        public MyAsyncICommand RunSimulationCommand { get; set; }



        public NewSimulationViewModel(ISessionContext sessionContext,
                                      IPrisonerSimulationFactory simulationFactory,
                                      IPrisonerSimulationExecutor simulationExecutor)
        {
            _sessionContext = sessionContext;
            _simulationFactory = simulationFactory;
            _simulationExecutor = simulationExecutor;

            _prisonerStrategies = 
                new ObservableCollection<PrisonerStrategy>(
                    Enum.GetValues(typeof(PrisonerStrategy)).Cast<PrisonerStrategy>());

            RunSimulationCommand = new MyAsyncICommand(RunSimulationsAsync, CanRunSimulations);
            SessionContext.IsSimulatingChanged += (object? sender, EventArgs e) => RunSimulationCommand.RaiseCanExecuteChanged();
        }



        private async Task RunSimulationsAsync()
        {
            var simulationModels = _simulationFactory.CreateSimulations(SimulationQuantity, PrisonerQuantity);

            if (SelectedPrisonerStrategy != null)
            {
                SessionContext.IsSimulating = true;


                var simulationTasks = simulationModels.Select(simulation => Task.Run(async () =>
                {
                    await _simulationExecutor.ExecuteSimulationAsync(simulation, (PrisonerStrategy)SelectedPrisonerStrategy);

                    return App.Mapper.Map<PrisonerSimulationWpfModel>(simulation);
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
                   SelectedPrisonerStrategy != null &&
                   SessionContext.IsSimulating == false;
        }
    }
}
