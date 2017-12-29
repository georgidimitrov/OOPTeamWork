namespace AlphaTank.Program.Models.Contracts
{
    public interface IMovableGameObject : IGameObject
    {
        string Direction { get; }

        void Move();
        bool MoveUp();
        bool MoveDown();
        bool MoveLeft();
        bool MoveRight();
    }
}
