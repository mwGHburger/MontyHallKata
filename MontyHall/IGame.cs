namespace MontyHall
{
    public interface IGame
    {
         void Run();
         bool DidContestantWin();
         void Reset();
    }
}