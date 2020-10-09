using System;
namespace MontyHall
{
    public class Randomiser : IRandomiser
    {
        public int GenerateNumber(int maxValue)
        {
            var random = new Random();
            return random.Next(maxValue);
        }
    }
}