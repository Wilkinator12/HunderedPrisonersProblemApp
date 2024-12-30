﻿using HunderedPrisonersProblemLibrary.Models;
using System.Collections.Generic;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface IAttemptFactory
    {
        List<Attempt> CreatePrisonerAttempts(List<Prisoner> prisoners);
    }
}