using AlphaTank.Program.Models.GameObjects.Common;

namespace AlphaTank.Program.Display.Contracts
{
    public interface ICollisionInfo
    {
        bool IsCollided { get; }

        GameObjectType Type { get; }
    }
}
