using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Bases;
using WpfUI.Contexts.Abstractions;
using WpfUI.Data;
using WpfUI.Models;

namespace WpfUI.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ISessionContext SessionContext { get; set; }



        public MainViewModel(ISessionContext sessionContext)
        {
            SessionContext = sessionContext;
        }
    }
}
