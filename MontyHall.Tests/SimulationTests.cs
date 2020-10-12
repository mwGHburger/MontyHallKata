using System;
using Moq;
using Xunit;

namespace MontyHall.Tests
{
    public class SimulationTests
    {
        [Fact]
        public void ShouldRunGames_ByAmountSpecified()
        {
            var mockGame = new Mock<IGame>();
            var totalRuns = 10;
            var simulation = new Simulation(mockGame.Object,totalRuns);

            simulation.Run();

            mockGame.Verify(x => x.Run(), Times.Exactly(totalRuns));
        }

        [Fact]
        public void ShouldIncrementWinCount_WhenContestantWinsGame()
        {
            var mockGame = new Mock<IGame>();
            var totalRuns = 5;
            var simulation = new Simulation(game: mockGame.Object, totalRuns: totalRuns);
            var expected = 5;

            mockGame.Setup(x =>x.DidContestantWin()).Returns(true);

            simulation.Run();
            var actual = simulation.TotalContestantWins;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SwitchStrategyHasAHigherWinRateThanNotSwitching_OverA1000Runs()
        {
            System.Console.WriteLine("Start");
            var doorQuantity = 3;
            var calculator = new Calculator();
            var switchStrategy = new Strategy(true);
            var stayStrategy = new Strategy(false);
            var simulation1 = new Simulation(new Game(doorQuantity: doorQuantity, new Randomiser(), new Contestant(switchStrategy), new Host()), 1000);
            var simulation2 = new Simulation(new Game(doorQuantity: doorQuantity, new Randomiser(), new Contestant(stayStrategy), new Host()), 1000);
            
            simulation1.Run();
            simulation2.Run();
            var switchWinRate =  calculator.CalculateWinPercentageInSimulation(simulation1);
            var stayWinRate =  calculator.CalculateWinPercentageInSimulation(simulation2);
            
            Assert.True(switchWinRate > stayWinRate);
            System.Console.WriteLine(switchWinRate);
            System.Console.WriteLine(stayWinRate);
            System.Console.WriteLine("End");
        }
    }
}
