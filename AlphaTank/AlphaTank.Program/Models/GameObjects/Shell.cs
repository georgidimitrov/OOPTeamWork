using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using System;
using System.Threading;

namespace AlphaTank.Program.Models.GameObjects
{
    public class Shell : GameObject, IMovableGameObject
    {
        private readonly Direction direction;
        private readonly GameObjectType gameObjectType;

        public Shell(int row, int col, Map map, Direction direction) : base(row, col)
        {
            this.Representative = '+';
            this.Color = ConsoleColor.DarkRed;
            this.Map = map;
            this.direction = direction;
            this.gameObjectType = GameObjectType.Shell;
            this.Spawn();
        }

        public GameObjectType GameObjectType => this.gameObjectType;
        public Direction Direction => this.direction;

        private void Spawn()
        {
            if (this.Map.GetMap[this.RowPosition, this.ColumnPosition] is Tank)
            {
                this.Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            }
            else if (this.Map.GetMap[this.RowPosition, this.ColumnPosition] is Obstacle)
            {
                this.Destroy();
            }
            else if (this.Map.GetMap[this.RowPosition, this.ColumnPosition] is Road)
            {
                this.Map.GetMap[this.RowPosition, this.ColumnPosition] = this;
            }
        }

        public ICollisionInfo Move()
        {
            if (Map != null)
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
            return new CollisionInfo(false);
        }

        public ICollisionInfo MoveDown()
        {
            this.IsThereAMap();
            Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.Map, this.RowPosition + 1, this.ColumnPosition))
            {
                IGameObject gameObject = this.Map.GetMap[this.RowPosition + 1, this.ColumnPosition];
                if (gameObject is PlayerTank)
                {
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (gameObject is EnemyTank)
                {
                    this.Map.GetMap[this.RowPosition + 1, this.ColumnPosition] = new Road(this.RowPosition + 1, this.ColumnPosition);
                    this.RowPosition++;
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                else if (gameObject is Shell)
                {
                    this.Map.GetMap[this.RowPosition + 1, this.ColumnPosition].Destroy();
                    this.Map.GetMap[this.RowPosition + 1, this.ColumnPosition] = new Road(this.RowPosition + 1, this.ColumnPosition);
                    this.RowPosition++;
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.Shell);
                }
                this.Destroy();
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                Map.GetMap[this.RowPosition + 1, this.ColumnPosition] = this;
                this.RowPosition++;
                return new CollisionInfo(false);
            }
        }

        public ICollisionInfo MoveLeft()
        {
            this.IsThereAMap();
            Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition - 1))
            {
                IGameObject gameObject = this.Map.GetMap[this.RowPosition, this.ColumnPosition - 1];
                if (gameObject is PlayerTank)
                {
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (gameObject is EnemyTank)
                {
                    this.Map.GetMap[this.RowPosition, this.ColumnPosition - 1] = new Road(this.RowPosition, this.ColumnPosition - 1);
                    this.ColumnPosition--;
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                else if (gameObject is Shell)
                {
                    this.Map.GetMap[this.RowPosition, this.ColumnPosition - 1].Destroy();
                    this.Map.GetMap[this.RowPosition, this.ColumnPosition - 1] = new Road(this.RowPosition, this.ColumnPosition - 1);
                    this.ColumnPosition--;
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.Shell);
                }
                this.Destroy();
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                Map.GetMap[this.RowPosition, this.ColumnPosition - 1] = this;
                this.ColumnPosition--;
                return new CollisionInfo(false);
            }
        }

        public ICollisionInfo MoveRight()
        {
            this.IsThereAMap();
            Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition + 1))
            {
                IGameObject gameObject = this.Map.GetMap[this.RowPosition, this.ColumnPosition + 1];
                if (gameObject is PlayerTank)
                {
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (gameObject is EnemyTank)
                {
                    Map.GetMap[this.RowPosition, this.ColumnPosition + 1] = new Road(this.RowPosition, this.ColumnPosition + 1);
                    this.ColumnPosition++;
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                else if (gameObject is Shell)
                {
                    Map.GetMap[this.RowPosition, this.ColumnPosition + 1].Destroy();
                    Map.GetMap[this.RowPosition, this.ColumnPosition + 1] = new Road(this.RowPosition, this.ColumnPosition + 1);
                    this.ColumnPosition++;
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.Shell);
                }
                this.Destroy();
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                Map.GetMap[this.RowPosition, this.ColumnPosition + 1] = this;
                this.ColumnPosition++;
                return new CollisionInfo(false);
            }
        }

        public ICollisionInfo MoveUp()
        {
            this.IsThereAMap();
            Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.Map, this.RowPosition - 1, this.ColumnPosition))
            {
                IGameObject gameObject = this.Map.GetMap[this.RowPosition - 1, this.ColumnPosition];
                if (gameObject is PlayerTank)
                {
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (gameObject is EnemyTank)
                {
                    Map.GetMap[this.RowPosition - 1, this.ColumnPosition] = new Road(this.RowPosition - 1, this.ColumnPosition);
                    this.RowPosition--;
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                else if (gameObject is Shell)
                {
                    Map.GetMap[this.RowPosition - 1, this.ColumnPosition].Destroy();
                    Map.GetMap[this.RowPosition - 1, this.ColumnPosition] = new Road(this.RowPosition - 1, this.ColumnPosition);
                    this.RowPosition--;
                    this.Destroy();
                    return new CollisionInfo(true, GameObjectType.Shell);
                }
                this.Destroy();
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                Map.GetMap[this.RowPosition - 1, this.ColumnPosition] = this;
                this.RowPosition--;
                return new CollisionInfo(false);
            }
        }

        public void IsThereAMap()
        {
            if (this.Map == null)
            {
                throw new NoMapException("No map to move shell in.");
            }
        }
    }

}
