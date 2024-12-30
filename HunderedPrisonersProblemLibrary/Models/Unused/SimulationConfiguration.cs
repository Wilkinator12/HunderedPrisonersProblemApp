using System.Collections.Generic;

namespace HunderedPrisonersProblemLibrary.Models.Unused
{
    // If I were to redo the program, I would have had this instead of PrisonerSimulationModel
    public class SimulationConfiguration
    {
        public List<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
        public BoxRoom BoxRoom { get; set; }
        public Strategy StrategyToUse { get; set; } = Strategy.CheckRandomBoxes;
    }
}
