using System.Collections.Generic;

namespace MontyHall
{
    public class Contestant : IContestant
    {
        public Door SelectedDoor { get; private set; }
        public void ChooseDoor(List<Door> doorsList, IRandomiser randomiser)
        {
            var maxDoors = doorsList.Count;
            var randomNumber = randomiser.GenerateNumber(maxDoors);
            var door = doorsList[randomNumber];
            door.HasBeenSelected = true;
            SelectedDoor = door;
        }

        public void EnactStrategy(List<Door> doorsList, Strategy strategy)
        {
            if (strategy.WillSwitchDoors)
            {
                SwitchDoors(doorsList);
            }
        }

        private void SwitchDoors(List<Door> doorsList)
        {
            foreach(Door door in doorsList)
            {
                var hasDoorNotBeenSelectedOrOpened = !(door.HasBeenSelected || door.HasBeenOpened);
                if (hasDoorNotBeenSelectedOrOpened)
                {
                    SelectedDoor.HasBeenSelected = false;
                    SelectedDoor = door;
                    door.HasBeenSelected = true;
                }
            }
        }
    }
}