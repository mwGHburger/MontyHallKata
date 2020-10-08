using System.Collections.Generic;

namespace MontyHall
{
    public class Game : IGame
    {

        public int DoorQuantity { get; private set;}
        public List<Door> DoorsList { get; private set;} = new List<Door>();

        public Game(int doorQuantity)
        {
            DoorQuantity = doorQuantity;
        }
        public void Run()
        {
            System.Console.WriteLine("game runs");
            CreateDoors(DoorQuantity);
            AssignDoorPrize();
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
            var randomNumber = 0;
            DoorsList[randomNumber].HasPrize = true;
        }
    }
}