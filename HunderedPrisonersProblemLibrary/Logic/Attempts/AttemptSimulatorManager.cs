using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Attempts.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.Attempts
{
    public class AttemptSimulatorManager : IAttemptSimulatorManager
    {
        private readonly IServiceProvider _serviceProvider;

        public AttemptSimulatorManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAttemptSimulator GetAttemptSimulator(Strategy strategy)
        {
            switch (strategy)
            {
                case Strategy.CheckRandomBoxes:
                    return _serviceProvider.GetService<RandomBoxAttemptSimulator>();

                case Strategy.FollowLoops:
                    return _serviceProvider.GetService<FollowLoopAttemptSimulator>();

                default:
                    throw new AggregateException("Invalid strategy!");
            }
        }
    }
}
