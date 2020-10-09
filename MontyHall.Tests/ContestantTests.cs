using System.Reflection.Metadata;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace MontyHall.Tests
{
    public class ContestantTests
    {
        [Fact]
        public void ShouldSelectSpecificDoor()
        {
            var expectedDoor = new Door();
            var doors = new List<Door>()
            {
                new Door(),
                expectedDoor,
                new Door()
            };
            var mockRandomiser = new Mock<IRandomiser>();
            var contestant = new Contestant();

            mockRandomiser.Setup(x => x.GenerateNumber(It.IsAny<int>())).Returns(1);

            contestant.ChooseDoor(doors, mockRandomiser.Object);
            var actualDoor = contestant.SelectedDoor;

            Assert.IsType<Door>(contestant.SelectedDoor);
            Assert.Same(expectedDoor,actualDoor);
        }

        [Fact]
        public void ContestantShouldHoldNewDoor_WhenSwitchStrategyIsTrue()
        {
            var expectedDoor = new Door();
            var doorWithPrize = new Door();
            doorWithPrize.HasPrize = true;
            var firstSelectedDoor = new Door();
            var doors = new List<Door>()
            {
                doorWithPrize,
                firstSelectedDoor,
                expectedDoor
            };
            var contestant = new Contestant();
            var mockRandomiser = new Mock<IRandomiser>();
            var strategy = new Strategy(true);

            mockRandomiser.Setup(x => x.GenerateNumber(It.IsAny<int>())).Returns(1);

            contestant.ChooseDoor(doorsList: doors, randomiser: mockRandomiser.Object);

            contestant.EnactStrategy(doorsList: doors, strategy: strategy);
            var actualDoor = contestant.SelectedDoor;

            Assert.Same(expectedDoor, actualDoor);
        }

        [Fact]
        public void ContestantShouldHoldSameDoor_WhenSwitchStrategyIsFalse()
        {
            var doorNotSelectedAndWithNoPrize = new Door();
            var doorWithPrize = new Door();
            doorWithPrize.HasPrize = true;
            var expectedDoor = new Door();
            var doors = new List<Door>()
            {
                doorWithPrize,
                expectedDoor,
                doorNotSelectedAndWithNoPrize
            };
            var contestant = new Contestant();
            var mockRandomiser = new Mock<IRandomiser>();
            var strategy = new Strategy(false);

            mockRandomiser.Setup(x => x.GenerateNumber(It.IsAny<int>())).Returns(1);

            contestant.ChooseDoor(doorsList: doors, randomiser: mockRandomiser.Object);

            contestant.EnactStrategy(doorsList: doors, strategy: strategy);
            var actualDoor = contestant.SelectedDoor;

            Assert.Same(expectedDoor, actualDoor);
        }
    }
}