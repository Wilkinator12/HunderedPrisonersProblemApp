using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts.Abstractions
{
    public interface IPrisonerAttemptSimulator
    {
        PrisonerAttemptModel ExecuteAttempt(BoxRoomModel boxRoom, PrisonerModel prisoner);
        Task<PrisonerAttemptModel> ExecuteAttemptAsync(BoxRoomModel boxRoom, PrisonerModel prisoner);
    }
}
