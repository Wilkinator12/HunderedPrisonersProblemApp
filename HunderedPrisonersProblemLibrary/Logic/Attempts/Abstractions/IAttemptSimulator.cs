using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HunderedPrisonersProblemLibrary.Logic.Attempts.Abstractions
{
    public interface IAttemptSimulator
    {
        Attempt ExecuteAttempt(BoxRoom boxRoom, Prisoner prisoner);
        Task<Attempt> ExecuteAttemptAsync(BoxRoom boxRoom, Prisoner prisoner);
    }
}
