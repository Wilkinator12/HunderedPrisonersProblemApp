using System.Collections.ObjectModel;
using WpfUI.Bases;

namespace WpfUI.Models
{
    public class AttemptModel : BindableBase
    {
        private PrisonerModel _attemptingPrisoner = null!;
        public PrisonerModel AttemptingPrisoner
        {
            get => _attemptingPrisoner;
            set 
            { 
                SetProperty(ref _attemptingPrisoner, value); 
            }
        }

        private ObservableCollection<BoxSelectionModel> _boxSelections = new ObservableCollection<BoxSelectionModel>();
        public ObservableCollection<BoxSelectionModel> BoxSelections
        {
            get => _boxSelections;
            set
            {
                SetProperty(ref _boxSelections, value);
            }
        }

        private bool _hasSucceeded;
        public bool HasSucceeded
        {
            get => _hasSucceeded;
            set
            {
                SetProperty(ref _hasSucceeded, value);
            }
        }

        private bool _attemptCompleted;
        public bool AttemptCompleted
        {
            get => _attemptCompleted;
            set
            {
                SetProperty(ref _attemptCompleted, value);
            }
        }
    }
}
