using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models;

namespace WpfUI.Contexts.Abstractions
{
    public interface ISessionContext : INotifyPropertyChanged
    {
        ObservableCollection<PrisonerSimulationWpfModel> Simulations { get; set; }
        PrisonerSimulationWpfModel? SelectedSimulation { get; set; }
        PrisonerAttemptWpfModel? SelectedPrisonerAttempt { get; set; }

        bool IsSimulating { get; set; }



        event EventHandler? IsSimulatingChanged;

        event EventHandler? NewSimulationBatchCompleted;
        void RaiseSimulationBatchChange();
    }
}
