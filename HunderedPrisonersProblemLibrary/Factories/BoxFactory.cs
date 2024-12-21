﻿using HunderedPrisonersProblemLibrary.Factories.Abstractions;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunderedPrisonersProblemLibrary.Factories
{
    public class BoxFactory : IBoxFactory
    {
        private readonly Random _rand;

        public BoxFactory(Random rand)
        {
            _rand = rand;
        }

        public List<BoxModel> CreateBoxes(int numberOfBoxes)
        {
            var output = new List<BoxModel>();

            var allContainedNumbers = Enumerable.Range(1, numberOfBoxes).ToList();
            allContainedNumbers.Shuffle(_rand);

            for (int i = 0; i < allContainedNumbers.Count; i++)
            {
                var newBox = new BoxModel { LabelNumber = i + 1, SlipNumber = allContainedNumbers[i] };

                output.Add(newBox);
            }

            return output;
        }
    }
}