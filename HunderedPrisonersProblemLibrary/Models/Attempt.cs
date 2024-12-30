using System.Collections.Generic;
using System.Linq;

namespace HunderedPrisonersProblemLibrary.Models
{
    public class Attempt
    {
        public Prisoner AttemptingPrisoner { get; set; }
        public List<BoxSelection> BoxSelections { get; set; } = new List<BoxSelection>();
        public bool HasSucceeded { get; set; } = false;
        public bool AttemptComplete { get; set; } = false;
    }
}
