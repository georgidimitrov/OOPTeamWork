using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models.Contracts;

namespace AlphaTank.Program.Models.GameObjects
{
    public class CollisionInfo : ICollisionInfo
    {
        private readonly bool collisionStatus;
        private readonly GameObjectType type;

        public CollisionInfo(bool collisionStatus, GameObjectType type = GameObjectType.Road)
        {
            this.collisionStatus = collisionStatus;
            this.type = type;
        }

        public bool CollisionStatus => this.collisionStatus;
        public GameObjectType Type => this.type;
    }
}