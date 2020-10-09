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
            SelectedDoor = door;
        }
    }
}