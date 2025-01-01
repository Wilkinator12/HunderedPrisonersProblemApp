using HunderedPrisonersProblemLibrary.Logic.SimulationLogic.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.AttemptLogic.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HunderedPrisonersProblemLibrary.Logic.AttemptLogic
{
    public class FollowLoopAttemptSimulator : IAttemptSimulator
    {
        private readonly IRiddleRules _rules;
        private readonly ILogger<FollowLoopAttemptSimulator> _logger;

        public FollowLoopAttemptSimulator(IRiddleRules rules, ILogger<FollowLoopAttemptSimulator> logger)
        {
            _rules = rules;
           _logger = logger;
        }


        public Attempt ExecuteAttempt(BoxRoom boxRoom, Prisoner prisoner)
        {
            var output = new Attempt { AttemptingPrisoner = prisoner };


            int numberOfBoxesToCheck = _rules.GetNumberOfBoxesToCheck(boxRoom);
            int nextLabelNumberToCheck = prisoner.IdentityNumber;

            for (int i = 0; i < numberOfBoxesToCheck; i++)
            {
                if (!boxRoom.BoxLabelDictionary.TryGetValue(nextLabelNumberToCheck, out Box currentBox))
                {
                    string message = $"Box label number {nextLabelNumberToCheck} was not found";
                    _logger.Log(LogLevel.Error, message);
                    throw new InvalidOperationException();
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
