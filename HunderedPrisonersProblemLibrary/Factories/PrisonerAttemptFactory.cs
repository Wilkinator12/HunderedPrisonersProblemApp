using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories
{
    public class PrisonerAttemptFactory : IPrisonerAttemptFactory
    {
        public List<PrisonerAttemptModel> CreatePrisonerAttempts(List<PrisonerModel> prisoners)
        {
            var output = new List<PrisonerAttemptModel>();

            foreach (var prisoner in prisoners)
            {
                var newAttempt = new PrisonerAttemptModel { AttemptingPrisoner = prisoner };

                output.Add(newAttempt);
            }

            return output;
        }
    }
}
