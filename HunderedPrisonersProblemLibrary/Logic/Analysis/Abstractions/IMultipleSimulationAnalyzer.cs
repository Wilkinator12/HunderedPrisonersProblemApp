using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.AnalysisLogic.Abstractions
{
    public interface IMultipleSimulationAnalyzer
    {
        double GetSuccessRate(List<Simulation> simulations);
    }
}
