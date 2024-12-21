using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories
{
    public class PrisonerFactory : IPrisonerFactory
    {
        public List<PrisonerModel> CreatePrisoners(int numberOfPrisoners)
        {
            var output = new List<PrisonerModel>();

            for (int i = 0; i < numberOfPrisoners; i++)
            {
                var newPrisoner = new PrisonerModel { IdentityNumber = i + 1 };

                output.Add(newPrisoner);
            }

            return output;
        }
    }
}
