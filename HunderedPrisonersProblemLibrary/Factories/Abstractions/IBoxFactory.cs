using HunderedPrisonersProblemLibrary.Models;
using System.Collections.Generic;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface IBoxFactory
    {
        List<Box> CreateBoxes(int numberOfBoxes);
    }
}
