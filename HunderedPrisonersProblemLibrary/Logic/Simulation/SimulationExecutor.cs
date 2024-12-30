using HunderedPrisonersProblemLibrary.Logic.SimulationLogic.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.AttemptLogic.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HunderedPrisonersProblemLibrary.Logic.SimulationLogic
{
    public class SimulationExecutor : ISimulationExecutor
    {
        private readonly IAttemptSimulatorManager _attemptManager;
        private readonly IRiddleRules _rules;

        public SimulationExecutor(IAttemptSimulatorManager attemptManager, IRiddleRules rules)
        {
            _attemptManager = attemptManager;
            _rules = rules;
        }


        public void ExecuteSimulation(Simulation simulation, Strategy strategy)
        {
            var attemptSimulator = _attemptManager.GetAttemptSimulator(strategy);

            foreach (var prisoner in simulation.Prisoners)
            {
                var attempt = attemptSimulator.ExecuteAttempt(simulation.BoxRoom, prisoner);
                simulation.Attempts.Add(attempt);
            }

            simulation.StrategyUsed = strategy;
            simulation.PrisonersSucceeded = _rules.PrisonersDidSucceed(simulation);
        }

        public async Task ExecuteSimulationAsync(Simulation simulation, Strategy strategy)
        {
            var attemptSimulator = _attemptManager.GetAttemptSimulator(strategy);

            var attemptTasks = simulation.Prisoners.Select(prisoner =>
            {
                return attemptSimulator.ExecuteAttemptAsync(simulation.BoxRoom, prisoner);
            });

            var attempts = await Task.WhenAll(attemptTasks);


            simulation.Attempts.AddRange(attempts);


            simulation.StrategyUsed = strategy;
            simulation.PrisonersSucceeded = _rules.PrisonersDidSucceed(simulation);
        }
    }
}
