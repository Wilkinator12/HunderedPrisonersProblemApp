using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HunderedPrisonersProblemLibrary.Logic.Simulation
{
    public class PrisonerSimulationExecutor : IPrisonerSimulationExecutor
    {
        private readonly IPrisonerAttemptSimulatorManager _attemptManager;

        public PrisonerSimulationExecutor(IPrisonerAttemptSimulatorManager attemptManager)
        {
            _attemptManager = attemptManager;
        }


        public void ExecuteSimulation(PrisonerSimulationModel simulation, PrisonerStrategy strategy)
        {
            var attemptSimulator = _attemptManager.GetPrisonerAttemptSimulator(strategy);

            foreach (var prisoner in simulation.Prisoners)
            {
                var attempt = attemptSimulator.ExecuteAttempt(simulation.BoxRoom, prisoner);
                simulation.Attempts.Add(attempt);
            }

            simulation.StrategyUsed = strategy;
        }

        public async Task ExecuteSimulationAsync(PrisonerSimulationModel simulation, PrisonerStrategy strategy)
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
