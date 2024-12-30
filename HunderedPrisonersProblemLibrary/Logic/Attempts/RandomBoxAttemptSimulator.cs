using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.Attempts.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HunderedPrisonersProblemLibrary.Logic.Attempts
{
    public class RandomBoxAttemptSimulator : IAttemptSimulator
    {
        private readonly IRiddleRules _gameRules;
        private readonly Random _rand;

        public RandomBoxAttemptSimulator(IRiddleRules gameRules, Random rand)
        {
            _gameRules = gameRules;
            _rand = rand;
        }


        public Attempt ExecuteAttempt(BoxRoom boxRoom, Prisoner prisoner)
        {
            var output = new Attempt()
            {
                AttemptingPrisoner = prisoner
            };


            int numberOfBoxesToCheck = _gameRules.GetNumberOfBoxesToCheck(boxRoom);
            var boxesLeftToCheck = new List<Box>(boxRoom.Boxes);

            for (int i = 0; i < numberOfBoxesToCheck; i++)
            {
                int currentBoxIndex = _rand.Next(0, boxesLeftToCheck.Count);
                var currentBox = boxesLeftToCheck[currentBoxIndex];

                output.BoxSelections.Add(new BoxSelection { SelectionNumber = i + 1, SelectedBox = currentBox });

                if (currentBox.SlipNumber == prisoner.IdentityNumber)
                {
                    output.HasSucceeded = true;
                    break;
                }
                
                boxesLeftToCheck.Remove(currentBox);
            }


            return output;
        }

        public async Task<Attempt> ExecuteAttemptAsync(BoxRoom boxRoom, Prisoner prisoner)
        {
            return ExecuteAttempt(boxRoom, prisoner);
        }
    }
}
