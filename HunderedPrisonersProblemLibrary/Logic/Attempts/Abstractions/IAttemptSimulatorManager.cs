using HunderedPrisonersProblemLibrary.Models;

namespace HunderedPrisonersProblemLibrary.Logic.AttemptLogic.Abstractions
{
    public interface IAttemptSimulatorManager
    {
        IAttemptSimulator GetAttemptSimulator(Strategy strategy);
    }
}
