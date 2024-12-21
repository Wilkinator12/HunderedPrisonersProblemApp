using HunderedPrisonersProblemLibrary.Factories;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundredPrisonersProblemLibrary.Tests.Factories
{
    public class BoxFactoryTests
    {
        [Fact]
        public void CreateBoxes_EveryContainedNumberFromOneToBoxCountIsRepresented()
        {
            // Arrange
            var boxFactory = new BoxFactory(new Random());
            int boxCount = 100;

            // Act
            var boxes = boxFactory.CreateBoxes(boxCount);

            // Assert
            var actualContainedNumbers = boxes.Select(b => b.SlipNumber);
            for (int expectedContainedNumber = 1; expectedContainedNumber <= boxCount; expectedContainedNumber++)
            {
                Assert.Contains(expectedContainedNumber, actualContainedNumbers);
            }
        }
    }
}
