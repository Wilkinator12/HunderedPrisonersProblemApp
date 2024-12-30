using System.Collections.ObjectModel;
using WpfUI.Models;

namespace WpfUI.Data
{
    public interface IUIDataAccess
    {
        ObservableCollection<string> GetRiddleRules();
        ObservableCollection<StrategyExplanation> GetStrategyExplanations();
    }
}