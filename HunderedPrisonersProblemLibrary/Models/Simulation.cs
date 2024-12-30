using System.Collections.Generic;
using System.Linq;

namespace HunderedPrisonersProblemLibrary.Models
{
    public class Simulation
    {
        public List<Prisoner> Prisoners { get; set; } = new List<Prisoner>();
        public BoxRoom BoxRoom { get; set; }
        public List<Attempt> Attempts { get; set; } = new List<Attempt>();
        public Strategy StrategyUsed { get; set; } = Strategy.CheckRandomBoxes;
        public bool PrisonersSucceeded => Attempts.All(a => a.HasSucceeded);
    }
}
