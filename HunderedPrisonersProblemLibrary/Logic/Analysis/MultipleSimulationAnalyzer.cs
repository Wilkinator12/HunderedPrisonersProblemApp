using HunderedPrisonersProblemLibrary.Logic.Analysis.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.Analysis
{
    public class MultipleSimulationAnalyzer : IMultipleSimulationAnalyzer
    {
        public double GetSuccessRate(List<Models.Simulation> simulations)
        {
            if (simulations.Any() == false) return 0;


            int numberOfSucceededSimulations = simulations.Where(s => s.PrisonersSucceeded == true).Count();

            return ((double)numberOfSucceededSimulations / simulations.Count);
        }
    }
}
