using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Bases;
using WpfUI.Data;
using WpfUI.Models;

namespace WpfUI.ViewModels
{
    public class HeaderViewModel : BindableBase
    {
        public ObservableCollection<string> RiddleRules { get; set; }
        public ObservableCollection<StrategyExplanationWpfModel> StrategyExplanations { get; set; }



        public HeaderViewModel(IUIDataAccess uiData)
        {
            RiddleRules = uiData.GetRiddleRules();
            StrategyExplanations = uiData.GetStrategyExplanations();
        }
    }
}
