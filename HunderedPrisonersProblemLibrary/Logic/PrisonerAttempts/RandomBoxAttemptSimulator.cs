using HunderedPrisonersProblemLibrary.Logic.Simulation.Abstractions;
using HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HunderedPrisonersProblemLibrary.Logic.PrisonerAttempts
{
    public class RandomBoxAttemptSimulator : IPrisonerAttemptSimulator
    {
        private readonly IRiddleRules _gameRules;
        private readonly Random _rand;

        public RandomBoxAttemptSimulator(IRiddleRules gameRules, Random rand)
        {
            _gameRules = gameRules;
            _rand = rand;
        }


        public PrisonerAttemptModel ExecuteAttempt(BoxRoomModel boxRoom, PrisonerModel prisoner)
        {
            var output = new PrisonerAttemptModel()
            {
                AttemptingPrisoner = prisoner
            };


            int numberOfBoxesToCheck = _gameRules.GetNumberOfBoxesToCheck(boxRoom);
            var boxesLeftToCheck = new List<BoxModel>(boxRoom.Boxes);

            for (int i = 0; i < numberOfBoxesToCheck; i++)
            {
                int currentBoxIndex = _rand.Next(0, boxesLeftToCheck.Count);
                var currentBox = boxesLeftToCheck[currentBoxIndex];

                output.BoxSelections.Add(new BoxSelectionModel { SelectionNumber = i + 1, SelectedBox = currentBox });

                if (currentBox.SlipNumber == prisoner.IdentityNumber)
                {
                    output.HasSucceeded = true;
                    break;
                }
                
                boxesLeftToCheck.Remove(currentBox);
            }


            return output;
        }

        public async Task<PrisonerAttemptModel> ExecuteAttemptAsync(BoxRoomModel boxRoom, PrisonerModel prisoner)
        {
            return ExecuteAttempt(boxRoom, prisoner);
        }
    }
}
