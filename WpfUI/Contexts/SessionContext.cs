using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Bases;
using WpfUI.Contexts.Abstractions;
using WpfUI.Models;

namespace WpfUI.Contexts
{
    public class SessionContext : BindableBase, ISessionContext
    {
        public ObservableCollection<PrisonerSimulationWpfModel> Simulations { get; set; } = new ObservableCollection<PrisonerSimulationWpfModel>();

        private PrisonerSimulationWpfModel? _selectedSimulation;
        public PrisonerSimulationWpfModel? SelectedSimulation 
        {
            get => _selectedSimulation;
            set
            {
                SetProperty(ref _selectedSimulation, value);
            }
        }

        private PrisonerAttemptWpfModel? _selectedPrisonerAttempt;
        public PrisonerAttemptWpfModel? SelectedPrisonerAttempt
        {
            get => _selectedPrisonerAttempt;
            set
            {
                SetProperty(ref _selectedPrisonerAttempt, value);
            }
        }

        private bool _isSimulating;
        public bool IsSimulating
        {
            get => _isSimulating;
            set 
            { 
                SetProperty(ref _isSimulating, value);
                RaiseIsSimulatingChanged();
            }
        }



        public event EventHandler? IsSimulatingChanged;
        private void RaiseIsSimulatingChanged()
        {
            IsSimulatingChanged?.Invoke(this, EventArgs.Empty);
        }



        public event EventHandler? NewSimulationBatchCompleted;
        public void RaiseSimulationBatchChange()
        {
            NewSimulationBatchCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
