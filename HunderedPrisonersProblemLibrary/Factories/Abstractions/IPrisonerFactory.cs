using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface IPrisonerFactory
    {
        List<PrisonerModel> CreatePrisoners(int numberOfPrisoners);
    }
}
