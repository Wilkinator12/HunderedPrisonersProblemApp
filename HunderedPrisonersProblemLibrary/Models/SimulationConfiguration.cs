using System.Collections.Generic;

namespace HunderedPrisonersProblemLibrary.Models
{
    // If I were to redo the program, I would have had this instead of PrisonerSimulationModel
    public class SimulationConfiguration
    {
        public List<PrisonerModel> Prisoners { get; set; } = new List<PrisonerModel>();
        public BoxRoomModel BoxRoom { get; set; }
        public PrisonerStrategy StrategyToUse { get; set; } = PrisonerStrategy.CheckRandomBoxes;
    }
}
