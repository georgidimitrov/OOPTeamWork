using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using System;
using System.Threading;

namespace AlphaTank.Program.Models.GameObjects
{
    public class Shell : GameObject, IMovableGameObject
    {
        private Map map;
        private readonly Direction direction;
        private readonly GameObjectType gameObjectType;

        public Shell(int row, int col, Map map, Direction direction) : base(row, col)
        {
            this.Representative = '+';
            this.Color = ConsoleColor.DarkRed;
            this.map = map;
            this.direction = direction;
            this.gameObjectType = GameObjectType.Shell;
            this.Spawn();
        }

        public GameObjectType GameObjectType => this.gameObjectType;
        public Direction Direction => this.direction;
        public Map Map => this.map;

        private void Spawn()
        {
            if (this.map.GetMap[this.RowPosition, this.ColumnPosition] is Tank)
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            }
            else if (this.map.GetMap[this.RowPosition, this.ColumnPosition] is Obstacle)
            {
                this.Destroy();
            }
            else if (this.map.GetMap[this.RowPosition, this.ColumnPosition] is Road)
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = this;
            }
        }

        public void Destroy()
        {
            this.map = null;
        }
        
        public ICollisionInfo Move()
        {
            if (map != null)
            {
                switch (Direction)
                {
                    case Direction.Up:
                        return this.MoveUp();
                    case Direction.Down:
                        return this.MoveDown();
                    case Direction.Left:
                        return this.MoveLeft();
                    case Direction.Right:
                        return this.MoveRight();
                }
            }
            this.IsThereAMap();
            return new CollisionInfo(false);
        }

        public ICollisionInfo MoveDown()
        {
            this.IsThereAMap();
            map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.map, this.RowPosition + 1, this.ColumnPosition))
            {
                IGameObject gameObject = this.map.GetMap[this.RowPosition + 1, this.ColumnPosition];
                if (gameObject is PlayerTank)
                {
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (gameObject is EnemyTank)
                {
                    this.map.GetMap[this.RowPosition + 1, this.ColumnPosition] = new Road(this.RowPosition + 1, this.ColumnPosition);
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                else if (gameObject is Shell)
                {
                    this.map.GetMap[this.RowPosition + 1, this.ColumnPosition] = new Road(this.RowPosition + 1, this.ColumnPosition);
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.Shell);
                }
                this.Destroy();
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                map.GetMap[this.RowPosition + 1, this.ColumnPosition] = this;
                this.RowPosition++;
                return new CollisionInfo(false);
            }
        }

        public ICollisionInfo MoveLeft()
        {
            this.IsThereAMap();
            map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition - 1))
            {
                IGameObject gameObject = this.map.GetMap[this.RowPosition, this.ColumnPosition - 1];
                if (gameObject is PlayerTank)
                {
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (gameObject is EnemyTank)
                {
                    this.map.GetMap[this.RowPosition, this.ColumnPosition - 1] = new Road(this.RowPosition, this.ColumnPosition - 1);
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                else if (gameObject is Shell)
                {
                    this.map.GetMap[this.RowPosition, this.ColumnPosition - 1] = new Road(this.RowPosition, this.ColumnPosition - 1); 
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.Shell);
                }
                this.Destroy();
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                map.GetMap[this.RowPosition, this.ColumnPosition - 1] = this;
                this.ColumnPosition--;
                return new CollisionInfo(false);
            }
        }

        public ICollisionInfo MoveRight()
        {
            this.IsThereAMap();
            map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition + 1))
            {
                IGameObject gameObject = this.map.GetMap[this.RowPosition, this.ColumnPosition + 1];
                if (gameObject is PlayerTank)
                {
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (gameObject is EnemyTank)
                {
                    map.GetMap[this.RowPosition, this.ColumnPosition + 1] = new Road(this.RowPosition, this.ColumnPosition + 1);
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                else if (gameObject is Shell)
                {
                    map.GetMap[this.RowPosition, this.ColumnPosition + 1] = new Road(this.RowPosition, this.ColumnPosition + 1);
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.Shell);
                }
                this.Destroy();
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMap[this.RowPosition, this.ColumnPosition + 1] = this;
                this.ColumnPosition++;
                return new CollisionInfo(false);
            }
        }

        public ICollisionInfo MoveUp()
        {
            this.IsThereAMap();
            map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.map, this.RowPosition - 1, this.ColumnPosition))
            {
                IGameObject gameObject = this.map.GetMap[this.RowPosition - 1, this.ColumnPosition];
                if (gameObject is PlayerTank)
                {
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (gameObject is EnemyTank)
                {
                    map.GetMap[this.RowPosition - 1, this.ColumnPosition] = new Road(this.RowPosition - 1, this.ColumnPosition);
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                else if (gameObject is Shell)
                {
                    map.GetMap[this.RowPosition - 1, this.ColumnPosition] = new Road(this.RowPosition - 1, this.ColumnPosition);
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.Shell);
                }
                this.Destroy();
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                map.GetMap[this.RowPosition - 1, this.ColumnPosition] = this;
                this.RowPosition--;
                return new CollisionInfo(false);
            }
        }

        public void IsThereAMap()
        {
            if (this.map == null)
            {
                throw new ArgumentNullException("No map to move shell in.");
            }
        }
    }

}
