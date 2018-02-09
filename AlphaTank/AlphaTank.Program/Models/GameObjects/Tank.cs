using AlphaTank.Program.Models.Contracts;
using System;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class Tank : GameObject, ITank, IMovableGameObject
    {
        private Direction direction = Direction.Up;
        private readonly IEnvironmentFactory environmentFactory;
        private readonly ICollision collision;

        public Tank(int row, int col, IMap map, IEnvironmentFactory environmentFactory, ICollision collision) : base(row, col)
        {
            this.Map = map ?? throw new ArgumentException("Tank: No map instance.");
            this.Map[base.RowPosition, base.ColumnPosition] = this;
            this.Representative = '^';
            this.environmentFactory = environmentFactory;
            this.collision = collision;
        }

        public ICollision Collision => this.collision;
        public Direction Direction
        {
            get { return this.direction; }
            protected set { this.direction = value; }
        }

        public virtual bool MoveDown()
        {
            if (this.Direction != Direction.Down)
            {
                Direction = Direction.Down;
                this.Representative = 'v';
                return false;
            }

            this.Representative = 'v';
            this.Direction = Direction.Down;
            if (!collision.DetectCollision(this.Map, this.RowPosition + 1, this.ColumnPosition))
            {
                Map[this.RowPosition + 1, this.ColumnPosition] = this;
                Map[this.RowPosition, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition);
                this.RowPosition++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool MoveLeft()
        {
            if (this.Direction != Direction.Left)
            {
                Direction = Direction.Left;
                this.Representative = '<';
                return false;
            }

            this.Representative = '<';
            this.Direction = Direction.Left;
            if (!collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition - 1))
            {
                Map[this.RowPosition, this.ColumnPosition - 1] = this;
                Map[this.RowPosition, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition);
                this.ColumnPosition--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool MoveRight()
        {
            if (this.Direction != Direction.Right)
            {
                Direction = Direction.Right;
                this.Representative = '>';
                return false;
            }

            this.Representative = '>';
            this.Direction = Direction.Right;
            if (!collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition + 1))
            {
                Map[this.RowPosition, this.ColumnPosition + 1] = this;
                Map[this.RowPosition, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition);
                this.ColumnPosition++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool MoveUp()
        {
            if (this.Direction != Direction.Up)
            {
                Direction = Direction.Up;
                this.Representative = '^';
                return false;
            }

            this.Representative = '^';
            this.Direction = Direction.Up;
            if (!collision.DetectCollision(this.Map, this.RowPosition - 1, this.ColumnPosition))
            {
                Map[this.RowPosition - 1, this.ColumnPosition] = this;
                Map[this.RowPosition, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition);
                this.RowPosition--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public IShell Shoot()
        {
            switch (this.Direction)
            {
                case Direction.Down:
                    return environmentFactory.CreateShell(this.RowPosition + 1, this.ColumnPosition, this.Map, this.Direction, environmentFactory, Collision);
                case Direction.Left:
                    return environmentFactory.CreateShell(this.RowPosition, this.ColumnPosition - 1, this.Map, this.Direction, environmentFactory, Collision);
                case Direction.Right:
                    return environmentFactory.CreateShell(this.RowPosition, this.ColumnPosition + 1, this.Map, this.Direction, environmentFactory, Collision);
                default:
                    return environmentFactory.CreateShell(this.RowPosition - 1, this.ColumnPosition, this.Map, this.Direction, environmentFactory, Collision);
            }
        }
    }
}

