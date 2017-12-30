using AlphaTank.Program.Display;
using AlphaTank.Program.Display.Contracts;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects.Common;
using System;
using System.Threading;

namespace AlphaTank.Program.Models.GameObjects
{
    public class Shell : GameObject, IMovableGameObject
    {
        private Map map;
        private readonly Direction direction;

        public Shell(int row, int col, Map map, Direction direction) : base(row, col)
        {
            this.Type = GameObjectType.Shell;
            this.Representative = '+';
            this.Color = ConsoleColor.DarkRed;

            this.map = map;
            this.direction = direction;
        }

        public Direction Direction => direction;

        public bool Spawn()
        {
            if (this.map.GetMap[this.RowPosition, this.ColumnPosition] is Tank)
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                return false;
            }
            else if (this.map.GetMap[this.RowPosition, this.ColumnPosition] is Obstacle)
            {
                return false;
            }
            else if (this.map.GetMap[this.RowPosition, this.ColumnPosition] is Road)
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = this;
                return true;
            }
            return false;
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
            throw new ArgumentException("No Map!");
        }

        public ICollisionInfo MoveDown()
        {
            if (Collision.DetectCollision(this.map, this.RowPosition + 1, this.ColumnPosition))
            {
                if (this.map.GetMap[this.RowPosition + 1, this.ColumnPosition] is PlayerTank)
                {
                    Thread.Sleep(1000);
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (this.map.GetMap[this.RowPosition + 1, this.ColumnPosition] is EnemyTank)
                {
                    map.GetMap[this.RowPosition + 1, this.ColumnPosition] = new Road(this.RowPosition + 1, this.ColumnPosition);
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMap[this.RowPosition + 1, this.ColumnPosition] = this;
                this.RowPosition++;
                return new CollisionInfo(false);
            }
        }

        public ICollisionInfo MoveLeft()
        {
            if (Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition - 1))
            {
                if (this.map.GetMap[this.RowPosition, this.ColumnPosition - 1] is PlayerTank)
                {
                    Thread.Sleep(1000);
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                    //Game Over
                }
                else if (this.map.GetMap[this.RowPosition, this.ColumnPosition - 1] is EnemyTank)
                {
                    map.GetMap[this.RowPosition, this.ColumnPosition - 1] = new Road(this.RowPosition, this.ColumnPosition - 1);
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMap[this.RowPosition, this.ColumnPosition - 1] = this;
                this.ColumnPosition--;
                return new CollisionInfo(false);
            }
        }

        public ICollisionInfo MoveRight()
        {
            if (Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition + 1))
            {
                if (this.map.GetMap[this.RowPosition, this.ColumnPosition + 1] is PlayerTank)
                {
                    Thread.Sleep(1000);
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                    //Game Over
                }
                else if (this.map.GetMap[this.RowPosition, this.ColumnPosition + 1] is EnemyTank)
                {
                    map.GetMap[this.RowPosition, this.ColumnPosition + 1] = new Road(this.RowPosition, this.ColumnPosition - 1);
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
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
            if (Collision.DetectCollision(this.map, this.RowPosition - 1, this.ColumnPosition))
            {
                if (this.map.GetMap[this.RowPosition - 1, this.ColumnPosition] is PlayerTank)
                {
                    Thread.Sleep(1000);
                    return new CollisionInfo(true, GameObjectType.PlayerTank);
                }
                else if (this.map.GetMap[this.RowPosition - 1, this.ColumnPosition] is EnemyTank)
                {
                    map.GetMap[this.RowPosition - 1, this.ColumnPosition] = new Road(this.RowPosition - 1, this.ColumnPosition);
                    return new CollisionInfo(true, GameObjectType.EnemyTank);
                }
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
            else
            {
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMap[this.RowPosition - 1, this.ColumnPosition] = this;
                this.RowPosition--;
                return new CollisionInfo(false);
            }
        }
    }
}
