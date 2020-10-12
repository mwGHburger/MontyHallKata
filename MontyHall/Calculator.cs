using System;

namespace MontyHall
{
    public class Calculator
    {
        public double CalculateWinProbabilityInSimulation(ISimulation simulation)
        {
            var winPercentage = Convert.ToDouble(simulation.TotalContestantWins) / simulation.TotalRuns;
            return winPercentage;
        }

        public string ConvertToPercentage(double winProbability)
        {
            return $"{winProbability * 100}%";
        }
    }
}