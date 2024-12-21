using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories
{
    public class PrisonerSimulationFactory : IPrisonerSimulationFactory
    {
        private readonly IPrisonerFactory _prisonerFactory;
        private readonly IBoxRoomFactory _boxRoomFactory;

        public PrisonerSimulationFactory(IPrisonerFactory prisonerFactory,
                                             IBoxRoomFactory boxRoomFactory)
        {
            _prisonerFactory = prisonerFactory;
            _boxRoomFactory = boxRoomFactory;
        }

        public PrisonerSimulationModel CreateSimulation(int numberOfPrisoners)
        {
            var prisoners = _prisonerFactory.CreatePrisoners(numberOfPrisoners);


            return new PrisonerSimulationModel()
            {
                Prisoners = prisoners,
                BoxRoom = _boxRoomFactory.CreateBoxRoom(numberOfPrisoners)
            };
        }

        public List<PrisonerSimulationModel> CreateSimulations(int numberOfSimulations, int numberOfPrisoners)
        {
            var output = new List<PrisonerSimulationModel>();


            for (int i = 0; i < numberOfSimulations; i++)
            {
                var newSimulation = CreateSimulation(numberOfPrisoners);

                output.Add(newSimulation);
            }


            return output;
        }
    }
}
