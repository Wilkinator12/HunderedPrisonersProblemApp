using HunderedPrisonersProblemLibrary.Models;

namespace HunderedPrisonersProblemLibrary.Logic.Attempts.Abstractions
{
    public interface IAttemptSimulatorManager
    {
        IAttemptSimulator GetPrisonerAttemptSimulator(Strategy strategy);
    }
}
