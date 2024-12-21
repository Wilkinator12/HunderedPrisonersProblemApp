using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Bases;

namespace WpfUI.Models
{
    public class StrategyExplanationWpfModel : BindableBase
    {
        private string _strategyName = string.Empty;
        public string StrategyName
        {
            get => _strategyName;
            set
            {
                SetProperty(ref _strategyName, value);
            }
        }

        private string _explanation = string.Empty;
        public string Explanation
        {
            get => _explanation;
            set
            {
                SetProperty(ref _explanation, value);
            }
        }
    }
}
