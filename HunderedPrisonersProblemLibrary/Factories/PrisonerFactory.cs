using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories
{
    public class PrisonerFactory : IPrisonerFactory
    {
        public List<Prisoner> CreatePrisoners(int numberOfPrisoners)
        {
            var output = new List<Prisoner>();

            for (int i = 0; i < numberOfPrisoners; i++)
            {
                var newPrisoner = new Prisoner { IdentityNumber = i + 1 };

                output.Add(newPrisoner);
            }

            return output;
        }
    }
}
