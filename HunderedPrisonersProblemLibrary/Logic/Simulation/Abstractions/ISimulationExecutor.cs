using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions
{
    public interface ISimulationExecutor
    {
        void ExecuteSimulation(Models.Simulation simulation, Strategy strategy);
        Task ExecuteSimulationAsync(Models.Simulation simulation, Strategy strategy);
    }
}
