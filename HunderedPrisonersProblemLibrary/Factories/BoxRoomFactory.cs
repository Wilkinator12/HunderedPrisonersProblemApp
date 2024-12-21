using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories
{
    public class BoxRoomFactory : IBoxRoomFactory
    {
        private readonly IBoxFactory _boxFactory;

        public BoxRoomFactory(IBoxFactory boxFactory)
        {
            _boxFactory = boxFactory;
        }

        public BoxRoomModel CreateBoxRoom(int numberOfBoxes)
        {
            return new BoxRoomModel { Boxes = _boxFactory.CreateBoxes(numberOfBoxes) };
        }
    }
}
