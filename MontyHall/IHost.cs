using System.Collections.Generic;

namespace MontyHall
{
    public interface IHost
    {
        Door RevealDoorWithNoPrize(List<Door> list);
    }
}