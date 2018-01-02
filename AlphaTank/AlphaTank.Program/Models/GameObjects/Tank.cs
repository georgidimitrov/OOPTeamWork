using AlphaTank.Program.Models.Contracts;
using System;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Enums_and_Structs;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class Tank : GameObject, ITank, IMovableGameObject
    {
        private Direction direction = Direction.Up;

        public Tank(int row, int col, Map map) : base(row, col)
        {
            this.Map = map ?? throw new ArgumentException("Tank: No map instance.");
            this.Map.GetMap[base.RowPosition, base.ColumnPosition] = this;
            this.Representative = '^';
        }

        public Direction Direction
        {
            get { return this.direction; }
            protected set { this.direction = value; }
        }

        public virtual ICollisionInfo MoveDown()
        {
            if (this.Direction != Direction.Down)
            {
                Direction = Direction.Down;
                this.Representative = 'v';
                return new CollisionInfo(false);
            }

            this.Representative = 'v';
            this.Direction = Direction.Down;
            if (!Collision.DetectCollision(this.Map, this.RowPosition + 1, this.ColumnPosition))
            {
                Map.GetMap[this.RowPosition + 1, this.ColumnPosition] = this;
                Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.RowPosition++;
                return new CollisionInfo(true);
            }
            else
            {
                return new CollisionInfo(false);
            }
        }

        public virtual ICollisionInfo MoveLeft()
        {
            if (this.Direction != Direction.Left)
            {
                Direction = Direction.Left;
                this.Representative = '<';
                return new CollisionInfo(false);
            }

            this.Representative = '<';
            this.Direction = Direction.Left;
            if (!Collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition - 1))
            {
                Map.GetMap[this.RowPosition, this.ColumnPosition - 1] = this;
                Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.ColumnPosition--;
                return new CollisionInfo(true);
            }
            else
            {
                return new CollisionInfo(false);
            }
        }

        public virtual ICollisionInfo MoveRight()
        {
            if (this.Direction != Direction.Right)
            {
                Direction = Direction.Right;
                this.Representative = '>';
                return new CollisionInfo(false);
            }

            this.Representative = '>';
            this.Direction = Direction.Right;
            if (!Collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition + 1))
            {
                Map.GetMap[this.RowPosition, this.ColumnPosition + 1] = this;
                Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.ColumnPosition++;
                return new CollisionInfo(true);
            }
            else
            {
                return new CollisionInfo(false);
            }
        }

        public virtual ICollisionInfo MoveUp()
        {
            if (this.Direction != Direction.Up)
            {
                Direction = Direction.Up;
                this.Representative = '^';
                return new CollisionInfo(false);
            }

            this.Representative = '^';
            this.Direction = Direction.Up;
            if (!Collision.DetectCollision(this.Map, this.RowPosition - 1, this.ColumnPosition))
            {
                Map.GetMap[this.RowPosition - 1, this.ColumnPosition] = this;
                Map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.RowPosition--;
                return new CollisionInfo(true);
            }
            else
            {
                return new CollisionInfo(false);
            }
        }

        public Shell Shoot()
        {
            switch (this.Direction)
            {
                case Direction.Down:
                    return new Shell(this.RowPosition + 1, this.ColumnPosition, this.Map, this.Direction);
                case Direction.Left:
                    return new Shell(this.RowPosition, this.ColumnPosition - 1, this.Map, this.Direction);
                case Direction.Right:
                    return new Shell(this.RowPosition, this.ColumnPosition + 1, this.Map, this.Direction);
                default:
                    return new Shell(this.RowPosition - 1, this.ColumnPosition, this.Map, this.Direction);
            }
        }
    }
}

