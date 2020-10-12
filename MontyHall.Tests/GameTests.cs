using System.Collections.Generic;
using Moq;
using Xunit;

namespace MontyHall.Tests
{
    public class GameTests
    {
        Mock<IContestant> mockContestant = new Mock<IContestant>();
        Mock<IRandomiser> mockRandomiser = new Mock<IRandomiser>();

        [Theory]
        [InlineData(3,3)]
        public void ShouldGenerateDoorsList_GivenQuantity_WhenGameRuns(int expected, int doorQuantity)
        {
            var game = new Game(doorQuantity: doorQuantity, randomiser: new Randomiser(), contestant: mockContestant.Object, host: new Host());
            
            game.Run();
            var actual = game.DoorsList.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldAssignDoorPrize_WhenGameRuns()
        {
            var game = new Game(doorQuantity: 3, randomiser: mockRandomiser.Object, contestant: mockContestant.Object, host: new Host());

            mockRandomiser.Setup(x => x.GenerateNumber(It.IsAny<int>())).Returns(0);

            game.Run();
            var actual = game.DoorsList[0].HasPrize;

            Assert.True(actual);
        }

        [Fact]
        public void ContestantShouldChooseDoor_WhenGameRuns()
        {
            var game = new Game(doorQuantity: 3, randomiser: new Randomiser(), mockContestant.Object, new Host());

            game.Run();

            mockContestant.Verify(x => x.ChooseDoor(It.IsAny<List<Door>>(), It.IsAny<IRandomiser>()));
        }

        [Fact]
        public void HostShouldOpenDoorWithNoPrize()
        {
            var mockHost = new Mock<IHost>();
            var game = new Game(doorQuantity: 3, randomiser: new Randomiser(), contestant: mockContestant.Object, host: mockHost.Object);

            game.Run();

            mockHost.Verify(x => x.RevealDoorWithNoPrize(It.IsAny<List<Door>>()));
        }

        // TODO: Should I verify whether Game.Run() calls Contestant.EnactStrategy()
        [Fact]
        public void ShouldReturnTrue_WhenContestantSelectsWinningDoor()
        {
            var game = new Game(doorQuantity: 3, randomiser: mockRandomiser.Object, contestant: mockContestant.Object, host: new Host());
            var winningDoor = new Door();
            winningDoor.HasPrize = true;
            
            mockContestant.Setup(x => x.SelectedDoor).Returns(winningDoor);

            var actual = game.DidContestantWin();

            Assert.True(actual);
        }

        [Fact]
        public void ShouldReturnFalse_WhenContestantSelectsLosingDoor()
        {
            var game = new Game(doorQuantity: 3, randomiser: new Randomiser(), contestant: mockContestant.Object, host: new Host());
            var losingDoor = new Door();
            losingDoor.HasPrize = false;
            
            mockContestant.Setup(x => x.SelectedDoor).Returns(losingDoor);
            
            var actual = game.DidContestantWin();

            Assert.False(actual);
        }

        [Fact]
        public void ResettingGameShouldRemoveDoors()
        {
            var game = new Game(doorQuantity: 3, randomiser: new Randomiser(), contestant: new Contestant(new Strategy(false)), host: new Host());

            game.Run();
            
            var actualSizeBeforeResest = game.DoorsList.Count; 
            Assert.Equal(3, actualSizeBeforeResest);
            
            game.Reset();

            var actualSizeAfterReset = game.DoorsList.Count; 
            Assert.Equal(0, actualSizeAfterReset);
        }
    }
}