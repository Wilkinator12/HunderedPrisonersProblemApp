using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts
{
    public class FollowLoopAttemptSimulator : IPrisonerAttemptSimulator
    {
        private readonly IRiddleRules _gameRules;

        public FollowLoopAttemptSimulator(IRiddleRules gameRules)
        {
            _gameRules = gameRules;
        }


        public PrisonerAttemptModel ExecuteAttempt(BoxRoomModel boxRoom, PrisonerModel prisoner)
        {
            var output = new PrisonerAttemptModel()
            {
                AttemptingPrisoner = prisoner
            };


            int numberOfBoxesToCheck = _gameRules.GetNumberOfBoxesToCheck(boxRoom);
            int nextLabelNumberToCheck = prisoner.IdentityNumber;

            for (int i = 0; i < numberOfBoxesToCheck; i++)
            {
                if (!boxRoom.BoxLabelDictionary.TryGetValue(nextLabelNumberToCheck, out BoxModel currentBox))
                {
                    throw new InvalidOperationException($"Box label number {nextLabelNumberToCheck} was not found");
                }


                output.BoxSelections.Add(new BoxSelectionModel { SelectionNumber = i + 1, SelectedBox = currentBox });

                if (currentBox.SlipNumber == prisoner.IdentityNumber)
                {
                    output.HasSucceeded = true;
                    break;
                }


                nextLabelNumberToCheck = currentBox.SlipNumber;
            }


            return output;
        }

        public async Task<PrisonerAttemptModel> ExecuteAttemptAsync(BoxRoomModel boxRoom, PrisonerModel prisoner)
        {
            return ExecuteAttempt(boxRoom, prisoner);
        }
    }
}
