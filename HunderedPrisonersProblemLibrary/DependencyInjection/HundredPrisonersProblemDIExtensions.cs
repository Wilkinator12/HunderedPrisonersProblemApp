using HunderedPrisonersProblemLibrary.Factories;
using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Analysis;
using HunderedPrisonersProblemLibrary.Logic.Analysis.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Simulation;
using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Attempts;
using HunderedPrisonersProblemLibrary.Logic.Attempts.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HundredPrisonersProblemDIExtensions
    {
        public static IServiceCollection AddHundredPrisonersProblemLibrary(this IServiceCollection services)
        {
            services.AddTransient<IPrisonerFactory, PrisonerFactory>();
            services.AddTransient<IBoxFactory, BoxFactory>();
            services.AddTransient<IBoxRoomFactory, BoxRoomFactory>();
            services.AddTransient<IAttemptFactory, AttemptFactory>();
            services.AddTransient<ISimulationFactory, SimulationFactory>();

            services.AddTransient<IMultipleSimulationAnalyzer, MultipleSimulationAnalyzer>();

            services.AddTransient<IRiddleRules, RiddleRules>();
            services.AddTransient<ISimulationExecutor, SimulationExecutor>();

            services.AddTransient<IAttemptSimulatorManager, AttemptSimulatorManager>();
            services.AddTransient<RandomBoxAttemptSimulator>();
            services.AddTransient<FollowLoopAttemptSimulator>();

            services.AddSingleton(new Random());

            return services;
        }
    }
}
