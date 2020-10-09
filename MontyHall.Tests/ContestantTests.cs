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
    }
}