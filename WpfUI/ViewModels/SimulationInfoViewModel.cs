using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Bases;
using WpfUI.Contexts.Abstractions;

namespace WpfUI.ViewModels
{
    public class SimulationInfoViewModel : BindableBase
    {
        public ISessionContext SessionContext { get; set; }

        public SimulationInfoViewModel(ISessionContext sessionContext)
        {
            SessionContext = sessionContext;
        }
    }
}
