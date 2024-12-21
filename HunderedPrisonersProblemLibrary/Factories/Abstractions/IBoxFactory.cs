using HunderedPrisonersProblemLibrary.Models;
using System.Collections.Generic;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface IBoxFactory
    {
        List<BoxModel> CreateBoxes(int numberOfBoxes);
    }
}
