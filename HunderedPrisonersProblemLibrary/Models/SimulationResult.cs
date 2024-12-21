using System.Collections.Generic;

namespace HunderedPrisonersProblemLibrary.Models
{
    // If I were to redo the program, I would have had this instead of just PrisonerSimulationModel
    public class SimulationResult
    {
        public SimulationConfiguration OriginalConfiguration { get; set; }
        public List<PrisonerAttemptModel> Attempts { get; set; } = new List<PrisonerAttemptModel>();
        public PrisonerStrategy StrategyUsed { get; set; } = PrisonerStrategy.CheckRandomBoxes;
        public bool PrisonersSucceeded { get; set; }
    }
}
