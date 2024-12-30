using HunderedPrisonersProblemLibrary.Logic.SimulationLogic.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.SimulationLogic
{
    public class RiddleRules : IRiddleRules
    {
        public int GetNumberOfBoxesToCheck(BoxRoom boxRoom)
        {
            return boxRoom.Boxes.Count / 2;
        }

        public bool PrisonersDidSucceed(Simulation simulation)
        {
            return simulation.Attempts.All(a => a.HasSucceeded);
        }
    }
}
