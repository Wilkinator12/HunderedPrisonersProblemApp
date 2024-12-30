using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Attempts.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HunderedPrisonersProblemLibrary.Logic.Attempts
{
    public class FollowLoopAttemptSimulator : IAttemptSimulator
    {
        private readonly IRiddleRules _gameRules;

        public FollowLoopAttemptSimulator(IRiddleRules gameRules)
        {
            _gameRules = gameRules;
        }


        public Attempt ExecuteAttempt(BoxRoom boxRoom, Prisoner prisoner)
        {
            var output = new Attempt()
            {
                AttemptingPrisoner = prisoner
            };


            int numberOfBoxesToCheck = _gameRules.GetNumberOfBoxesToCheck(boxRoom);
            int nextLabelNumberToCheck = prisoner.IdentityNumber;

            for (int i = 0; i < numberOfBoxesToCheck; i++)
            {
                if (!boxRoom.BoxLabelDictionary.TryGetValue(nextLabelNumberToCheck, out Box currentBox))
                {
                    throw new InvalidOperationException($"Box label number {nextLabelNumberToCheck} was not found");
                }


                output.BoxSelections.Add(new BoxSelection { SelectionNumber = i + 1, SelectedBox = currentBox });

                if (currentBox.SlipNumber == prisoner.IdentityNumber)
                {
                    output.HasSucceeded = true;
                    break;
                }


                nextLabelNumberToCheck = currentBox.SlipNumber;
            }


            return output;
        }

        public async Task<Attempt> ExecuteAttemptAsync(BoxRoom boxRoom, Prisoner prisoner)
        {
            return ExecuteAttempt(boxRoom, prisoner);
        }
    }
}
