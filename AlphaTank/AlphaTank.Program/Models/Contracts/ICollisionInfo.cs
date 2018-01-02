using AlphaTank.Program.Enums_and_Structs;

namespace AlphaTank.Program.Models.Contracts
{
    public interface ICollisionInfo
    {
        bool CollisionStatus { get; }
        GameObjectType Type { get; }
    }
}