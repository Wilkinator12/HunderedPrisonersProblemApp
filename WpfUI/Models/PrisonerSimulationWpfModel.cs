using HunderedPrisonersProblemLibrary.Models;
using System.Collections.ObjectModel;
using WpfUI.Bases;

namespace WpfUI.Models
{
    public class PrisonerSimulationWpfModel : BindableBase
    {
        private ObservableCollection<PrisonerWpfModel> _prisoners = new ObservableCollection<PrisonerWpfModel>();
        public ObservableCollection<PrisonerWpfModel> Prisoners
        {
            get => _prisoners;
            set
            {
                SetProperty(ref _prisoners, value);
            }
        }

        private BoxRoomWpfModel _boxRoom = null!;
        public BoxRoomWpfModel BoxRoom
        {
            get => _boxRoom;
            set
            {
                SetProperty(ref _boxRoom, value);
            }
        }

        private ObservableCollection<PrisonerAttemptWpfModel> _attempts = new ObservableCollection<PrisonerAttemptWpfModel>();
        public ObservableCollection<PrisonerAttemptWpfModel> Attempts
        {
            get => _attempts;
            set
            {
                SetProperty(ref _attempts, value);
            }
        }

        private PrisonerStrategy _strategyUsed;
        public PrisonerStrategy StrategyUsed
        {
            get => _strategyUsed;
            set
            {
                SetProperty(ref _strategyUsed, value);
            }
        }


        private bool _prisonersSucceeded;
        public bool PrisonersSucceeded
        {
            get => _prisonersSucceeded;
            set
            {
                SetProperty(ref _prisonersSucceeded, value);
            }
        }

        private bool _simulationComplete;
        public bool SimulationComplete
        {
            get => _simulationComplete;
            set
            {
                SetProperty(ref _simulationComplete, value);
            }
        }
    }
}
