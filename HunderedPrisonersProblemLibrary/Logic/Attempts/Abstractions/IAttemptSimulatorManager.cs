using HunderedPrisonersProblemLibrary.Models;

namespace HunderedPrisonersProblemLibrary.Logic.Attempts.Abstractions
{
    public interface IAttemptSimulatorManager
    {
        IAttemptSimulator GetAttemptSimulator(Strategy strategy);
    }
}
