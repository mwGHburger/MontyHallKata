using System;
using Moq;
using Xunit;

namespace MontyHall.Tests
{
    public class SimulationTests
    {
        Mock<IGame> mockGame = new Mock<IGame>();
        [Theory]
        [InlineData(10)]
        public void ShouldRunGames_ByAmountSpecified(int totalRuns)
        {
            var simulation = new Simulation(game: mockGame.Object, totalRuns: totalRuns);

            simulation.Run();

            mockGame.Verify(x => x.Run(), Times.Exactly(totalRuns));
        }

        [Theory]
        [InlineData(5,5)]
        public void ShouldIncrementWinCount_WhenContestantWinsGame(int expectedWinCount, int totalRuns)
        {
            var simulation = new Simulation(game: mockGame.Object, totalRuns: totalRuns);

            mockGame.Setup(x =>x.DidContestantWin()).Returns(true);

            simulation.Run();
            var actualWinCount = simulation.TotalContestantWins;

            Assert.Equal(expectedWinCount, actualWinCount);
        }

        [Theory]
        [InlineData(3,1000)]
        public void SwitchStrategyHasAHigherWinRateThanNotSwitching_OverA1000Runs(int doorQuantity, int totalRuns)
        {
            var calculator = new Calculator();
            var switchStrategy = new Strategy(true);
            var stayStrategy = new Strategy(false);
            var simulation1 = new Simulation(new Game(doorQuantity: doorQuantity, new Randomiser(), new Contestant(switchStrategy), new Host()), totalRuns);
            var simulation2 = new Simulation(new Game(doorQuantity: doorQuantity, new Randomiser(), new Contestant(stayStrategy), new Host()), totalRuns);
            
            simulation1.Run();
            simulation2.Run();
            var switchWinRate =  calculator.CalculateWinProbabilityInSimulation(simulation1);
            var stayWinRate =  calculator.CalculateWinProbabilityInSimulation(simulation2);
            
            Assert.True(switchWinRate > stayWinRate);
        }
    }
}
