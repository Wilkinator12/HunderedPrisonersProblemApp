using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Bases;
using WpfUI.Contexts.Abstractions;

namespace WpfUI.ViewModels
{
    public class BoxSelectionInfoViewModel : BindableBase
    {
        public ISessionContext SessionContext { get; set; }


        public BoxSelectionInfoViewModel(ISessionContext sessionContext)
        {
            SessionContext = sessionContext;
        }
    }
}
