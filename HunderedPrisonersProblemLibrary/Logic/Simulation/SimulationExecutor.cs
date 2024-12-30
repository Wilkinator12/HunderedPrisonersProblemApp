using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Attempts.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HunderedPrisonersProblemLibrary.Logic.Simulation
{
    public class SimulationExecutor : ISimulationExecutor
    {
        private readonly IAttemptSimulatorManager _attemptManager;

        public SimulationExecutor(IAttemptSimulatorManager attemptManager)
        {
            _attemptManager = attemptManager;
        }


        public void ExecuteSimulation(Models.Simulation simulation, Strategy strategy)
        {
            var attemptSimulator = _attemptManager.GetPrisonerAttemptSimulator(strategy);

            foreach (var prisoner in simulation.Prisoners)
            {
                var attempt = attemptSimulator.ExecuteAttempt(simulation.BoxRoom, prisoner);
                simulation.Attempts.Add(attempt);
            }

            simulation.StrategyUsed = strategy;
        }

        public async Task ExecuteSimulationAsync(Models.Simulation simulation, Strategy strategy)
        {
            var attemptSimulator = _attemptManager.GetPrisonerAttemptSimulator(strategy);

            var attemptTasks = simulation.Prisoners.Select(prisoner =>
            {
                return attemptSimulator.ExecuteAttemptAsync(simulation.BoxRoom, prisoner);
            });

            var attempts = await Task.WhenAll(attemptTasks);


            simulation.Attempts.AddRange(attempts);


            simulation.StrategyUsed = strategy;
        }
    }
}
