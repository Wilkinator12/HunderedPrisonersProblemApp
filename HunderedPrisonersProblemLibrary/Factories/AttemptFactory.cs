using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories
{
    public class AttemptFactory : IAttemptFactory
    {
        public List<Attempt> CreatePrisonerAttempts(List<Prisoner> prisoners)
        {
            var output = new List<Attempt>();

            foreach (var prisoner in prisoners)
            {
                var newAttempt = new Attempt { AttemptingPrisoner = prisoner };

                output.Add(newAttempt);
            }

            return output;
        }
    }
}
