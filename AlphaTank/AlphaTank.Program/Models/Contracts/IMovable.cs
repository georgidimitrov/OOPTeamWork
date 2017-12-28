namespace AlphaTank.Program.Models.Contracts
{
    public interface IMovable
    {
        bool MoveUp();
        bool MoveDown();
        bool MoveLeft();
        bool MoveRight();
    }
}
