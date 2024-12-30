using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.SimulationLogic.Abstractions
{
    public interface IRiddleRules
    {
        int GetNumberOfBoxesToCheck(BoxRoom boxRoom);
        bool PrisonersDidSucceed(Simulation simulation);
    }
}
