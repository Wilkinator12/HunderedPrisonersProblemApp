﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfUI.ViewModels;

namespace WpfUI.Views
{
    /// <summary>
    /// Interaction logic for NewSimulationView.xaml
    /// </summary>
    public partial class NewSimulationView : UserControl
    {
        public NewSimulationView()
        {
            InitializeComponent();

            DataContext = App.ServiceProvider.GetService<NewSimulationViewModel>();
        }
    }
}
