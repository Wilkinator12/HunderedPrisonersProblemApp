using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts
{
    public class PrisonerAttemptSimulatorManager : IPrisonerAttemptSimulatorManager
    {
        private readonly IServiceProvider _serviceProvider;

        public PrisonerAttemptSimulatorManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPrisonerAttemptSimulator GetPrisonerAttemptSimulator(PrisonerStrategy strategy)
        {
            switch (strategy)
            {
                case PrisonerStrategy.CheckRandomBoxes:
                    return _serviceProvider.GetService<RandomBoxAttemptSimulator>();

                case PrisonerStrategy.FollowLoops:
                    return _serviceProvider.GetService<FollowLoopAttemptSimulator>();

                default:
                    throw new AggregateException("Invalid strategy!");
            }
        }
    }
}
