using System.Collections.Generic;
using Xunit;

namespace MontyHall.Tests
{
    public class HostTests
    {
        Door firstDoor = new Door();
        Door selectedDoor = new Door();
        Door expectedDoor = new Door();
        
        [Fact]
        public void ShouldReturnDoorNotChosen_AndWithPrize_WhenOneDoorIsSelectedAnotherWithPrize()
        {
            var doors = new List<Door>()
            {
                firstDoor,
                selectedDoor,
                expectedDoor
            };
            firstDoor.HasPrize = true;
            selectedDoor.HasBeenSelected = true;
            var host = new Host();

            var actual = host.RevealDoorWithNoPrize(doors);

            Assert.Same(expectedDoor, actual);
            Assert.False(actual.HasPrize);
            Assert.False(actual.HasBeenSelected);
            Assert.True(actual.HasBeenOpened);
        }

        [Fact]
        public void ShouldReturnDoorNotChosen_AndWithPrize_WhenOneDoorIsSelectedAndHasPrize()
        {
            var doors = new List<Door>()
            {
                firstDoor,
                expectedDoor,
                new Door()
            };
            firstDoor.HasPrize = true;
            firstDoor.HasBeenSelected = true;
            var host = new Host();

            var actual = host.RevealDoorWithNoPrize(doors);

            Assert.Same(expectedDoor, actual);
            Assert.False(actual.HasPrize);
            Assert.False(actual.HasBeenSelected);
            Assert.True(actual.HasBeenOpened);
        }
    }
}