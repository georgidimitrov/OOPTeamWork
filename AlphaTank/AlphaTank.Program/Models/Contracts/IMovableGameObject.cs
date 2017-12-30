using AlphaTank.Program.Display.Contracts;
using AlphaTank.Program.Models.GameObjects.Common;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IMovableGameObject : IGameObject
    {
        Direction Direction { get; }
        ICollisionInfo MoveUp();
        ICollisionInfo MoveDown();
        ICollisionInfo MoveLeft();
        ICollisionInfo MoveRight();
    }
}
