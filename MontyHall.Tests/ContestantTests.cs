using System.Reflection.Metadata;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace MontyHall.Tests
{
    public class ContestantTests
    {
        Mock<IRandomiser> mockRandomiser = new Mock<IRandomiser>();
        Door expectedDoor = new Door();
        Door doorWithPrize = new Door();
        
        [Fact]
        public void ShouldSelectSpecificDoor()
        {
            var doors = new List<Door>()
            {
                new Door(),
                expectedDoor,
                new Door()
            };
            
            var strategy = new Strategy(true);
            var contestant = new Contestant(strategy);

            mockRandomiser.Setup(x => x.GenerateNumber(It.IsAny<int>())).Returns(1);

            contestant.ChooseDoor(doors, mockRandomiser.Object);
            var actualDoor = contestant.SelectedDoor;

            Assert.IsType<Door>(contestant.SelectedDoor);
            Assert.Same(expectedDoor,actualDoor);
        }

        [Fact]
        public void ContestantShouldHoldNewDoor_WhenSwitchStrategyIsTrue()
        {
            var firstSelectedDoor = new Door();
            var secondSelectedDoor = new Door();
            var doors = new List<Door>()
            {
                secondSelectedDoor,
                firstSelectedDoor,
            };
            var strategy = new Strategy(true);
            var contestant = new Contestant(strategy);

            mockRandomiser.Setup(x => x.GenerateNumber(It.IsAny<int>())).Returns(1);

            contestant.ChooseDoor(doorsList: doors, randomiser: mockRandomiser.Object);
            contestant.EnactStrategy(doorsList: doors);
            var actualDoor = contestant.SelectedDoor;
            Assert.Same(secondSelectedDoor, actualDoor);
        }

        [Fact]
        public void ContestantShouldHoldSameDoor_WhenSwitchStrategyIsFalse()
        {
            doorWithPrize.HasPrize = true;
            var doorNotSelectedAndWithNoPrize = new Door();
            var doors = new List<Door>()
            {
                doorWithPrize,
                expectedDoor,
                doorNotSelectedAndWithNoPrize
            };
            var strategy = new Strategy(false);
            var contestant = new Contestant(strategy);

            mockRandomiser.Setup(x => x.GenerateNumber(It.IsAny<int>())).Returns(1);

            contestant.ChooseDoor(doorsList: doors, randomiser: mockRandomiser.Object);
            contestant.EnactStrategy(doorsList: doors);
            var actualDoor = contestant.SelectedDoor;

            Assert.Same(expectedDoor, actualDoor);
        }
    }
}