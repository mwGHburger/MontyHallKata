using System;

namespace MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            var doorQuantity = 3;
            var totalRuns = 1000;
            var calculator = new Calculator();
            var switchStrategy = new Strategy(true);
            var stayStrategy = new Strategy(false);
            var simulation1 = new Simulation(new Game(doorQuantity: doorQuantity, new Randomiser(), new Contestant(switchStrategy), new Host()), totalRuns);
            var simulation2 = new Simulation(new Game(doorQuantity: doorQuantity, new Randomiser(), new Contestant(stayStrategy), new Host()), totalRuns);
            
            simulation1.Run();
            var switchWinRate =  calculator.CalculateWinProbabilityInSimulation(simulation1);
            simulation2.Run();
            var stayWinRate =  calculator.CalculateWinProbabilityInSimulation(simulation2);

            Console.WriteLine(
            $"The win percentage of the SWITCH strategy is {calculator.ConvertToPercentage(switchWinRate)}\n"+
            $"The win percentage of the STAY strategy is {calculator.ConvertToPercentage(stayWinRate)}");
        }
    }
}
