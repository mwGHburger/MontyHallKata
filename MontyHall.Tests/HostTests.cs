using System.Collections.Generic;
using Xunit;

namespace MontyHall.Tests
{
    public class HostTests
    {
        [Fact]
        public void ShouldReturnDoorNotChosen_AndWithPrize()
        {
            var expectedDoor = new Door();
            var doors = new List<Door>()
            {
                new Door(),
                new Door(),
                expectedDoor
            };
            doors[0].HasPrize = true;
            doors[1].HasBeenSelected = true;
            var host = new Host();

            var actual = host.RevealDoorWithNoPrize(doors);

            Assert.Same(expectedDoor, actual);
        }
    }
}