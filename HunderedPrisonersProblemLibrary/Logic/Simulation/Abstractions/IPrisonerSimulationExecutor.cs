using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions
{
    public interface IPrisonerSimulationExecutor
    {
        void ExecuteSimulation(PrisonerSimulationModel simulation, PrisonerStrategy strategy);
        Task ExecuteSimulationAsync(PrisonerSimulationModel simulation, PrisonerStrategy strategy);
    }
}
