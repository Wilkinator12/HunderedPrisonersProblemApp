using System.Collections.Generic;
using System.Linq;

namespace HunderedPrisonersProblemLibrary.Models
{
    public class PrisonerSimulationModel
    {
        public List<PrisonerModel> Prisoners { get; set; } = new List<PrisonerModel>();
        public BoxRoomModel BoxRoom { get; set; }
        public List<PrisonerAttemptModel> Attempts { get; set; } = new List<PrisonerAttemptModel>();
        public PrisonerStrategy StrategyUsed { get; set; } = PrisonerStrategy.CheckRandomBoxes;
        public bool PrisonersSucceeded => Attempts.All(a => a.HasSucceeded);
    }
}
