using System;
using System.Collections.Generic;

namespace MontyHall
{
    public class Host : IHost
    {
        public Door RevealDoorWithNoPrize(List<Door> doorList) {
            foreach(Door door in doorList)
            {
                if (!(door.HasBeenSelected || door.HasPrize))
                {
                    door.HasBeenOpened = true;
                    return door;
                }
            }
            throw new Exception();
        }
    }
}