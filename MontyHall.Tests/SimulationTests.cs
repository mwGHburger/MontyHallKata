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

            // TODO: no need to setup return mockGame.Setup(x => x.Run)
            simulation.Run();

            mockGame.Verify(x => x.Run(), Times.Exactly(totalRuns));
        }

        [Fact]
        public void ShouldIncrementWinCount_WhenContestantWinsGame()
        {
            var mockGame = new Mock<IGame>();
            var totalRuns = 5;
            var simulation = new Simulation(mockGame.Object, totalRuns);
            var expected = 5;

            mockGame.Setup(x =>x.DidContestantWin()).Returns(true);

            simulation.Run();
            var actual = simulation.TotalContestantWins;

            Assert.Equal(expected, actual);
        }
    }
}
