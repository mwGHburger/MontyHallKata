using System;

namespace MontyHall
{
    public class Calculator
    {
        public double CalculateWinPercentageInSimulation(ISimulation simulation)
        {
            var winPercentage = Convert.ToDouble(simulation.TotalContestantWins) / simulation.TotalRuns;
            return winPercentage;
        }
    }
}