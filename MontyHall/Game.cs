using System.Collections.Generic;

namespace MontyHall
{
    public class Game : IGame
    {

        public int DoorQuantity { get; private set;}
        public List<Door> DoorsList { get; private set;} = new List<Door>();
        public IRandomiser Randomiser { get; private set; }
        public IContestant Contestant { get; private set; }
        public IHost Host { get; private set; }

        public Game(int doorQuantity, IRandomiser randomiser, IContestant contestant, IHost host)
        {
            DoorQuantity = doorQuantity;
            Randomiser = randomiser;
            Contestant = contestant;
            Host = host;
        }
        public void Run()
        {
            CreateDoors(DoorQuantity);
            AssignDoorPrize();
            Contestant.ChooseDoor(doorsList: DoorsList, randomiser: Randomiser);
            Host.RevealDoorWithNoPrize(DoorsList);
            Contestant.EnactStrategy(DoorsList);
        }

        public void Reset()
        {
            DoorsList = new List<Door>();
        }

        public bool DidContestantWin()
        {
            return Contestant.SelectedDoor.HasPrize;
        }
        
        private void CreateDoors(int doorQuantity)
        {
            
            for(int i = 0; i < doorQuantity; i++)
            {
                DoorsList.Add(new Door());
            }
        }

        private void AssignDoorPrize()
        {
            var randomNumber = Randomiser.GenerateNumber(DoorQuantity);
            DoorsList[randomNumber].HasPrize = true;
        }
    }
}