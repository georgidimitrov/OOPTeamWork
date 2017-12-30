using AlphaTank.Program.Models.GameObjects;
using System;

namespace AlphaTank.Program.Models.Contracts
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