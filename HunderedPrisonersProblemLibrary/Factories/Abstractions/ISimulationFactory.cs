using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface ISimulationFactory
    {
        Simulation CreateSimulation(int numberOfPrisoners);
        List<Simulation> CreateSimulations(int numberOfSimulations, int numberOfPrisoners);
    }
}
