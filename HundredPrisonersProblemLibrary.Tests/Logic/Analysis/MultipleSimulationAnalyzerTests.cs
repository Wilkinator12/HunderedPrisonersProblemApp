using HunderedPrisonersProblemLibrary.Logic.AnalysisLogic;
using HunderedPrisonersProblemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundredPrisonersProblemLibrary.Tests.Logic.Analysis
{
    public class MultipleSimulationAnalyzerTests
    {
        [Theory]
        [InlineData(0, 0, 0)] // No simulations
        [InlineData(10, 0, 0)] // No successes
        [InlineData(10, 5, 0.5)] // Half successful
        [InlineData(10, 10, 1)] // All successful
        public void GetSuccessRate_ReturnsExpectedValue(int numberOfSimulations, int numberOfSuccesses, double expected)
        {
            // Arrange
            var analyzer = new MultipleSimulationAnalyzer();
            var simulations = new List<Simulation>();

            for (int i = 0; i < numberOfSimulations; i++)
            {
                simulations.Add(new Simulation
                {
                    PrisonersSucceeded = i < numberOfSuccesses
                });
            }

            // Act
            double actual = analyzer.GetSuccessRate(simulations);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
