using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HunderedPrisonersProblemLibrary.Logic.SimulationLogic.Abstractions
{
    public interface ISimulationExecutor
    {
        void ExecuteSimulation(Models.Simulation simulation);
        Task ExecuteSimulationAsync(Models.Simulation simulation);
        void SetStrategyToUse(Strategy strategy);
    }
}
