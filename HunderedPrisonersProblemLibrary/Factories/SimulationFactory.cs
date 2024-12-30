using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories
{
    public class SimulationFactory : ISimulationFactory
    {
        private readonly IPrisonerFactory _prisonerFactory;
        private readonly IBoxRoomFactory _boxRoomFactory;

        public SimulationFactory(IPrisonerFactory prisonerFactory,
                                             IBoxRoomFactory boxRoomFactory)
        {
            _prisonerFactory = prisonerFactory;
            _boxRoomFactory = boxRoomFactory;
        }

        public Simulation CreateSimulation(int numberOfPrisoners)
        {
            var prisoners = _prisonerFactory.CreatePrisoners(numberOfPrisoners);


            return new Simulation()
            {
                Prisoners = prisoners,
                BoxRoom = _boxRoomFactory.CreateBoxRoom(numberOfPrisoners)
            };
        }

        public List<Simulation> CreateSimulations(int numberOfSimulations, int numberOfPrisoners)
        {
            var output = new List<Simulation>();


            for (int i = 0; i < numberOfSimulations; i++)
            {
                var newSimulation = CreateSimulation(numberOfPrisoners);

                output.Add(newSimulation);
            }


            return output;
        }
    }
}
