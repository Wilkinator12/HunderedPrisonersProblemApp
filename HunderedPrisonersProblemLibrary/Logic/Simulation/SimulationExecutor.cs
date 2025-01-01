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


        private IAttemptSimulator attemptSimulator;


        public Strategy StrategyToUse { get; private set; }


        public SimulationExecutor(IAttemptSimulatorManager attemptManager, IRiddleRules rules)
        {
            _attemptManager = attemptManager;
            _rules = rules;

            SetStrategyToUse(Strategy.CheckRandomBoxes);
        }


        public void ExecuteSimulation(Simulation simulation)
        {
            foreach (var prisoner in simulation.Prisoners)
            {
                var attempt = attemptSimulator.ExecuteAttempt(simulation.BoxRoom, prisoner);
                simulation.Attempts.Add(attempt);
            }

            simulation.StrategyUsed = StrategyToUse;
            simulation.PrisonersSucceeded = _rules.PrisonersDidSucceed(simulation);
        }

        public async Task ExecuteSimulationAsync(Simulation simulation)
        {
            var attemptTasks = simulation.Prisoners.Select(prisoner =>
            {
                return attemptSimulator.ExecuteAttemptAsync(simulation.BoxRoom, prisoner);
            });

            var attempts = await Task.WhenAll(attemptTasks);


            simulation.Attempts.AddRange(attempts);


            simulation.StrategyUsed = StrategyToUse;
            simulation.PrisonersSucceeded = _rules.PrisonersDidSucceed(simulation);
        }

        public void SetStrategyToUse(Strategy strategy)
        {
            StrategyToUse = strategy;
            attemptSimulator = _attemptManager.GetAttemptSimulator(StrategyToUse);
        }
    }
}
