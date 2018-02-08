using AlphaTank.Program.Display.Contracts;
using AlphaTank.Program.Models.GameObjects.Common;

namespace AlphaTank.Program.Display
{
    public class CollisionInfo : ICollisionInfo
    {
        public CollisionInfo(bool isCollided, GameObjectType type = GameObjectType.Road)
        {
            this.IsCollided = isCollided;
            if (isCollided)
            {
                this.Type = type;
            }
        }

        public bool IsCollided { get; }
        public GameObjectType Type { get; }
    }
}
