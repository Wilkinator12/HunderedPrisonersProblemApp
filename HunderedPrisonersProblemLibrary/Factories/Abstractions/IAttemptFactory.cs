using HunderedPrisonersProblemLibrary.Models;
using System.Collections.Generic;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface IAttemptFactory
    {
        List<Attempt> CreateAttempts(List<Prisoner> prisoners);
    }
}
