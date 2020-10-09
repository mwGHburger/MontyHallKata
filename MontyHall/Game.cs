using System.Collections.Generic;

namespace MontyHall
{
    public class Game : IGame
    {

        public int DoorQuantity { get; private set;}
        public List<Door> DoorsList { get; private set;} = new List<Door>();
        public IRandomiser Randomiser { get; private set; }
        public IContestant Contestant { get; private set; }

        public Game(int doorQuantity, IRandomiser randomiser, IContestant contestant)
        {
            DoorQuantity = doorQuantity;
            Randomiser = randomiser;
            Contestant = contestant;
        }
        public void Run()
        {
            System.Console.WriteLine("game runs");
            CreateDoors(DoorQuantity);
            AssignDoorPrize();
            Contestant.ChooseDoor(doorsList: DoorsList, randomiser: Randomiser);
        }

        public bool DidContestantWin()
        {
            return true;
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