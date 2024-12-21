using System.Collections.ObjectModel;
using WpfUI.Bases;

namespace WpfUI.Models
{
    public class PrisonerAttemptWpfModel : BindableBase
    {
        private PrisonerWpfModel _attemptingPrisoner = null!;
        public PrisonerWpfModel AttemptingPrisoner
        {
            get => _attemptingPrisoner;
            set 
            { 
                SetProperty(ref _attemptingPrisoner, value); 
            }
        }

        private ObservableCollection<BoxSelectionWpfModel> _boxSelections = new ObservableCollection<BoxSelectionWpfModel>();
        public ObservableCollection<BoxSelectionWpfModel> BoxSelections
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
