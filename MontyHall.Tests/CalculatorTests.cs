using Moq;
using Xunit;

namespace MontyHall.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void ShouldReturnPercentageOfWins_GivenSimulation()
        {
            var expected = 0.65;
            var mockSimulation = new Mock<ISimulation>();
            var calculator = new Calculator();
            
            mockSimulation.Setup(x => x.TotalRuns).Returns(100);
            mockSimulation.Setup(x => x.TotalContestantWins).Returns(65);

            var actual = calculator.CalculateWinPercentageInSimulation(mockSimulation.Object);

            Assert.Equal(expected, actual);
        }
    }
}