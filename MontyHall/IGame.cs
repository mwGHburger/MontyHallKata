namespace MontyHall
{
    public interface IGame
    {
         void Run();
         bool DidContestantWin();
         void Reset();
         // TODO: Delete when done
         int DoorQuantity { get; }
    }
}