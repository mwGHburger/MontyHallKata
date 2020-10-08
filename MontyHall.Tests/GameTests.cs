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
            var game = new Game(doorQuantity: doorQuantity);

            game.Run();
            var actual = game.DoorsList.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldAssignDoorPrize_WhenGameRuns()
        {
            var game = new Game(doorQuantity: 3);

            game.Run();

            var actual = game.DoorsList[0].HasPrize;

            Assert.True(actual);
        }
    }
}