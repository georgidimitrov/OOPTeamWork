using AlphaTank.Program.Enums_and_Structs;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IMissile
    {
        Direction Direction { get; }
        ICollisionInfo MoveUp();
        ICollisionInfo MoveDown();
        ICollisionInfo MoveLeft();
        ICollisionInfo MoveRight();
    }
}
