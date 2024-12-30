using HunderedPrisonersProblemLibrary.Logic.AnalysisLogic.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.AnalysisLogic
{
    public class MultipleSimulationAnalyzer : IMultipleSimulationAnalyzer
    {
        public double GetSuccessRate(List<Simulation> simulations)
        {
            if (simulations.Any() == false) return 0;


            int numberOfSucceededSimulations = simulations.Where(s => s.PrisonersSucceeded == true).Count();

            return ((double)numberOfSucceededSimulations / simulations.Count);
        }
    }
}
