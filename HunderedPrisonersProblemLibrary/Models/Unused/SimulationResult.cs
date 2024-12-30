using System.Collections.Generic;

namespace HunderedPrisonersProblemLibrary.Models.Unused
{
    // If I were to redo the program, I would have had this instead of just PrisonerSimulationModel
    public class SimulationResult
    {
        public SimulationConfiguration OriginalConfiguration { get; set; }
        public List<Attempt> Attempts { get; set; } = new List<Attempt>();
        public Strategy StrategyUsed { get; set; } = Strategy.CheckRandomBoxes;
        public bool PrisonersSucceeded { get; set; }
    }
}
