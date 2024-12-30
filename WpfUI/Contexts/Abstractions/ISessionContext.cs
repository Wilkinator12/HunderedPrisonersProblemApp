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
        ObservableCollection<SimulationModel> Simulations { get; set; }
        SimulationModel? SelectedSimulation { get; set; }
        AttemptModel? SelectedPrisonerAttempt { get; set; }

        bool IsSimulating { get; set; }



        event EventHandler? IsSimulatingChanged;

        event EventHandler? NewSimulationBatchCompleted;
        void RaiseSimulationBatchChange();
    }
}
