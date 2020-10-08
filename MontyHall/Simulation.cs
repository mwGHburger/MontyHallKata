namespace MontyHall
{
    public class Simulation : ISimulation
    {
        public Simulation(IGame game, int totalRuns)
        {
            Game = game;
            TotalRuns = totalRuns;
        }

        public IGame Game { get; private set; }
        public int TotalRuns {get; private set; }
        public int TotalContestantWins { get; private set; }

        public void Run()
        {
            for(int i = 0; i < TotalRuns; i++)
            {
                Game.Run();
                if (Game.DidContestantWin())
                {
                    TotalContestantWins++;
                }
            }
        }
    }
}