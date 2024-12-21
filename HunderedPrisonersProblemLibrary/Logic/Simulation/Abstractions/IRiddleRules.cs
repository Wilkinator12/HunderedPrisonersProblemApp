using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions
{
    public interface IRiddleRules
    {
        int GetNumberOfBoxesToCheck(BoxRoomModel boxRoom);
    }
}
