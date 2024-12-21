using HunderedPrisonersProblemLibrary.Models;

namespace HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts.Abstractions
{
    public interface IPrisonerAttemptSimulatorManager
    {
        IPrisonerAttemptSimulator GetPrisonerAttemptSimulator(PrisonerStrategy strategy);
    }
}
