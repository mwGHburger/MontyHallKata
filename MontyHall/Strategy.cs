namespace MontyHall
{
    public class Strategy
    {
        public bool WillSwitchDoors {get; private set; }
        public Strategy(bool willSwitchDoors)
        {
            WillSwitchDoors = willSwitchDoors;
        }
    }
}