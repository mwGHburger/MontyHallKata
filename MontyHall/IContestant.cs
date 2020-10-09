using System.Collections.Generic;

namespace MontyHall
{
    public interface IContestant
    {
        void ChooseDoor(List<Door> doorsList, IRandomiser randomiser);
    }
}