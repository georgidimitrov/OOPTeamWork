using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models.GameObjects;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IMovableGameObject : IGameObject
    {
        Direction Direction { get; }
        bool MoveUp();
        bool MoveDown();
        bool MoveLeft();
        bool MoveRight();
    }
}
