using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface IPrisonerSimulationFactory
    {
        PrisonerSimulationModel CreateSimulation(int numberOfPrisoners);
        List<PrisonerSimulationModel> CreateSimulations(int numberOfSimulations, int numberOfPrisoners);
    }
}
