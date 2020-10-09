using System.Collections.Generic;
using Moq;
using Xunit;

namespace MontyHall.Tests
{
    public class GameTests
    {
        [Theory]
        [InlineData(3,3)]
        public void ShouldGenerateDoorsList_GivenQuantity_WhenGameRuns(int expected, int doorQuantity)
        {
            var game = new Game(doorQuantity: doorQuantity, randomiser: new Randomiser(), contestant: new Contestant());
            
            game.Run();
            var actual = game.DoorsList.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldAssignDoorPrize_WhenGameRuns()
        {
            var mockRandomiser = new Mock<IRandomiser>();
            var game = new Game(doorQuantity: 3, randomiser: mockRandomiser.Object, new Contestant());

            mockRandomiser.Setup(x => x.GenerateNumber(It.IsAny<int>())).Returns(0);

            game.Run();
            var actual = game.DoorsList[0].HasPrize;

            Assert.True(actual);
        }

        [Fact]
        public void ContestantShouldChooseDoor_WhenGameRuns()
        {
            var mockContestant = new Mock<IContestant>();
            var game = new Game(doorQuantity: 3, randomiser: new Randomiser(), mockContestant.Object);

            game.Run();

            mockContestant.Verify(x => x.ChooseDoor(It.IsAny<List<Door>>(), It.IsAny<IRandomiser>()));
        }

        [Fact]
        public void HostShouldOpenDoorWithNoPrize()
        {
            var mockHost = new Mock<Host>();
            var game = new Game(doorQuantity: 3, randomiser: new Randomiser(), new Contestant(), mockHost.Object);

            game.Run();

            mockHost.Verify(x => x.RevealDoorWithNoPrize(It.IsAny<List<Door>>()));
        }
    }
}