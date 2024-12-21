using System.Collections.Generic;
using System.Linq;

namespace HunderedPrisonersProblemLibrary.Models
{
    public class PrisonerAttemptModel
    {
        public PrisonerModel AttemptingPrisoner { get; set; }
        public List<BoxSelectionModel> BoxSelections { get; set; } = new List<BoxSelectionModel>();
        public bool HasSucceeded { get; set; } = false;
        public bool AttemptComplete { get; set; } = false;
    }
}
