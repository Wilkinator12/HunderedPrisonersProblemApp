using HunderedPrisonersProblemLibrary.Models;
using System.Collections.ObjectModel;
using WpfUI.Bases;

namespace WpfUI.Models
{
    public class SimulationModel : BindableBase
    {
        private ObservableCollection<PrisonerModel> _prisoners = new ObservableCollection<PrisonerModel>();
        public ObservableCollection<PrisonerModel> Prisoners
        {
            get => _prisoners;
            set
            {
                SetProperty(ref _prisoners, value);
            }
        }

        private BoxRoomModel _boxRoom = null!;
        public BoxRoomModel BoxRoom
        {
            get => _boxRoom;
            set
            {
                SetProperty(ref _boxRoom, value);
            }
        }

        private ObservableCollection<AttemptModel> _attempts = new ObservableCollection<AttemptModel>();
        public ObservableCollection<AttemptModel> Attempts
        {
            get => _attempts;
            set
            {
                SetProperty(ref _attempts, value);
            }
        }

        private Strategy _strategyUsed;
        public Strategy StrategyUsed
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
