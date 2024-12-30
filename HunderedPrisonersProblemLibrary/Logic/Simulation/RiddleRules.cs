using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.Simulation
{
    public class RiddleRules : IRiddleRules
    {
        public int GetNumberOfBoxesToCheck(BoxRoom boxRoom)
        {
            return boxRoom.Boxes.Count / 2;
        }
    }
}
