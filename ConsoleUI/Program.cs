﻿using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Analysis.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    public class Program
    {
        private static IServiceProvider serviceProvider = null!;


        static void Main(string[] args)
        {
            ConfigureDependencyInjection();

            var simFactory = serviceProvider.GetService<IPrisonerSimulationFactory>();
            var simulationExecutor = serviceProvider.GetService<IPrisonerSimulationExecutor>();
            var analyzer = serviceProvider.GetService<IMultipleSimulationAnalyzer>();


            int numberOfSimulations = 1000;
            var simulations = new List<PrisonerSimulationModel>();

            for (int i = 0; i < numberOfSimulations; i++)
            {
                var simulation = simFactory!.CreateSimulation(100);
                simulationExecutor!.ExecuteSimulation(simulation, PrisonerStrategy.FollowLoops);

                simulations.Add(simulation);
            }



            Console.WriteLine($"Success rate: {analyzer!.GetSuccessRate(simulations)}%");
        }



        private static void ConfigureDependencyInjection()
        {
            var services = new ServiceCollection();
            services.AddHundredPrisonersProblemLibrary();

            serviceProvider = services.BuildServiceProvider();
        }
    }
}