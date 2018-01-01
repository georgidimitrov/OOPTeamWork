using AlphaTank.Program.Display;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models.GameObjects;

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
