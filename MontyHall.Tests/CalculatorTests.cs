using Moq;
using Xunit;

namespace MontyHall.Tests
{
    public class CalculatorTests
    {
        Calculator calculator = new Calculator();
        Mock<ISimulation> mockSimulation = new Mock<ISimulation>();
        
        [Theory]
        [InlineData(0.65,100,65)]
        public void ShouldReturnProbabilityOfWins_GivenSimulation(double expected, int totalRuns, int totalContestantWins)
        {
            mockSimulation.Setup(x => x.TotalRuns).Returns(totalRuns);
            mockSimulation.Setup(x => x.TotalContestantWins).Returns(totalContestantWins);

            var actual = calculator.CalculateWinProbabilityInSimulation(mockSimulation.Object);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("65%",100,65)]
        public void ShouldReturnStringRepresentationOfWinPercentage(string expected, int totalRuns, int totalContestantWins)
        {
            mockSimulation.Setup(x => x.TotalRuns).Returns(totalRuns);
            mockSimulation.Setup(x => x.TotalContestantWins).Returns(totalContestantWins);

            var winRate = calculator.CalculateWinProbabilityInSimulation(mockSimulation.Object);
            var actual = calculator.ConvertToPercentage(winRate);

            Assert.Equal(expected, actual);
        }
    }
}