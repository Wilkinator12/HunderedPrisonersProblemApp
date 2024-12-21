using HunderedPrisonersProblemLibrary.Models;
using System.Collections.Generic;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface IPrisonerAttemptFactory
    {
        List<PrisonerAttemptModel> CreatePrisonerAttempts(List<PrisonerModel> prisoners);
    }
}
