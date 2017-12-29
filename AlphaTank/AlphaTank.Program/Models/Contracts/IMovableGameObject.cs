namespace AlphaTank.Program.Models.Contracts
{
    public interface IMovableGameObject : IGameObject
    {
        string Direction { get; }
        bool MoveUp();
        bool MoveDown();
        bool MoveLeft();
        bool MoveRight();
    }
}
