using HunderedPrisonersProblemLibrary.Factories;
using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Analysis;
using HunderedPrisonersProblemLibrary.Logic.Analysis.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Simulation;
using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts;
using HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts.Abstractions;
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
            services.AddTransient<IPrisonerAttemptFactory, PrisonerAttemptFactory>();
            services.AddTransient<IPrisonerSimulationFactory, PrisonerSimulationFactory>();

            services.AddTransient<IMultipleSimulationAnalyzer, MultipleSimulationAnalyzer>();

            services.AddTransient<IRiddleRules, RiddleRules>();
            services.AddTransient<IPrisonerSimulationExecutor, PrisonerSimulationExecutor>();

            services.AddTransient<IPrisonerAttemptSimulatorManager, PrisonerAttemptSimulatorManager>();
            services.AddTransient<RandomBoxAttemptSimulator>();
            services.AddTransient<FollowLoopAttemptSimulator>();

            services.AddSingleton(new Random());

            return services;
        }
    }
}
