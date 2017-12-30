using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program;
using System;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Display.Contracts;
using AlphaTank.Program.Display;
using AlphaTank.Program.Models.GameObjects.Common;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class Tank : GameObject, ITank, IMovableGameObject
    {
        private Direction direction = Direction.Up;
        private readonly Map map;

        public Tank(int row, int col, Map map) : base(row, col)
        {
            if (map == null)
            {
                throw new ArgumentException("Tank: No map instance.");
            }
            this.map = map;
            this.map.GetMap[base.RowPosition, base.ColumnPosition] = this;
        }

        public Direction Direction
        {
            get { return this.direction; }
            protected set { this.direction = value; }
        }

        public void Move()
        {
        }

        public ICollisionInfo MoveDown()
        {
            this.Direction = Direction.Down;
            if (!Collision.DetectCollision(this.map, this.RowPosition + 1, this.ColumnPosition))
            {
                map.GetMap[this.RowPosition + 1, this.ColumnPosition] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.RowPosition++;
                return new CollisionInfo(false);
            }
            else
            {
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
        }

        public ICollisionInfo MoveLeft()
        {
            this.Direction = Direction.Left;
            if (!Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition - 1))
            {
                map.GetMap[this.RowPosition, this.ColumnPosition - 1] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.ColumnPosition--;
                return new CollisionInfo(false);
            }
            else
            {
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
        }

        public ICollisionInfo MoveRight()
        {
            this.Direction = Direction.Right;
            if (!Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition + 1))
            {
                map.GetMap[this.RowPosition, this.ColumnPosition + 1] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.ColumnPosition++;
                return new CollisionInfo(false);
            }
            else
            {
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
        }

        public ICollisionInfo MoveUp()
        {
            this.Direction = Direction.Up;
            if (!Collision.DetectCollision(this.map, this.RowPosition - 1, this.ColumnPosition))
            {
                map.GetMap[this.RowPosition - 1, this.ColumnPosition] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.RowPosition--;
                return new CollisionInfo(false);
            }
            else
            {
                return new CollisionInfo(true, GameObjectType.Obstacle);
            }
        }

        public Shell Shoot()
        {
            switch (this.Direction)
            {
                case Direction.Down:
                    var shell = new Shell(this.RowPosition + 1, this.ColumnPosition, this.map, Direction.Down);
                    if (shell.Spawn())
                    {
                        return shell;
                    }
                    else
                    {
                        return null;
                    }
                case Direction.Left:
                    shell = new Shell(this.RowPosition, this.ColumnPosition - 1, this.map, Direction.Left);
                    if (shell.Spawn())
                    {
                        return shell;
                    }
                    else
                    {
                        return null;
                    }
                case Direction.Right:
                    shell = new Shell(this.RowPosition, this.ColumnPosition + 1, this.map, Direction.Right);
                    if (shell.Spawn())
                    {
                        return shell;
                    }
                    else
                    {
                        return null;
                    }
                case Direction.Up:
                    shell = new Shell(this.RowPosition - 1, this.ColumnPosition, this.map, Direction.Up);
                    if (shell.Spawn())
                    {
                        return shell;
                    }
                    else
                    {
                        return null;
                    }
                default:
                    return null;
            }
        }

        public void Destroy()
        {
            Console.WriteLine("Waddup");
        }

    }
}

