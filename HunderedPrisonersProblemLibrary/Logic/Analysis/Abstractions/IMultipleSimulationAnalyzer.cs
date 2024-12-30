using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.Analysis.Abstractions
{
    public interface IMultipleSimulationAnalyzer
    {
        double GetSuccessRate(List<Models.Simulation> simulations);
    }
}
