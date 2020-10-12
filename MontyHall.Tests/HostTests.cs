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
        public void ShouldReturnDoorNotChosen_AndWithPrize()
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
        }
    }
}