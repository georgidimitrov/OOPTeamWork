using AlphaTank.Program.Models.Contracts;
using System;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class Tank : GameObject, ITank, IMovableGameObject, IObstacle
    {
        private Direction direction;
        private readonly IEnvironmentFactory environmentFactory;
        private readonly ICollision collision;

        public Tank(int row, int col, Direction direction, IMap map, IEnvironmentFactory environmentFactory, ICollision collision) : base(row, col, map)
        {
            this.Representative = '^';
            this.Direction = direction;

            this.environmentFactory = environmentFactory ?? throw new ArgumentNullException();
            this.collision = collision ?? throw new ArgumentNullException();

            this.Map[base.RowPosition, base.ColumnPosition] = this;
        }

        public ICollision Collision => this.collision;

        public Direction Direction
        {
            get { return this.direction; }
            protected set { this.direction = value; }
        }

        public bool MoveDown()
        {
            if (this.Direction != Direction.Down)
            {
                this.Direction = Direction.Down;
                this.Representative = 'v';

                return false;
            }

            this.Representative = 'v';
            this.Direction = Direction.Down;

            if (!this.collision.DetectCollision(this.Map, this.RowPosition + 1, this.ColumnPosition))
            {
                this.Map[this.RowPosition + 1, this.ColumnPosition] = this;
                this.Map[this.RowPosition, this.ColumnPosition] = this.environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition, this.Map);
                this.RowPosition++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveLeft()
        {
            if (this.Direction != Direction.Left)
            {
                this.Direction = Direction.Left;
                this.Representative = '<';

                return false;
            }

            this.Representative = '<';
            this.Direction = Direction.Left;

            if (!this.collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition - 1))
            {
                this.Map[this.RowPosition, this.ColumnPosition - 1] = this;
                this.Map[this.RowPosition, this.ColumnPosition] = this.environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition, this.Map);
                this.ColumnPosition--;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveRight()
        {
            if (this.Direction != Direction.Right)
            {
                this.Direction = Direction.Right;
                this.Representative = '>';

                return false;
            }

            this.Representative = '>';
            this.Direction = Direction.Right;

            if (!this.collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition + 1))
            {
                this.Map[this.RowPosition, this.ColumnPosition + 1] = this;
                this.Map[this.RowPosition, this.ColumnPosition] = this.environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition, this.Map);
                this.ColumnPosition++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveUp()

        {
            if (this.Direction != Direction.Up)
            {
                this.Direction = Direction.Up;
                this.Representative = '^';

                return false;
            }

            this.Representative = '^';
            this.Direction = Direction.Up;

            if (!this.collision.DetectCollision(this.Map, this.RowPosition - 1, this.ColumnPosition))
            {
                this.Map[this.RowPosition - 1, this.ColumnPosition] = this;
                this.Map[this.RowPosition, this.ColumnPosition] = this.environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition, this.Map);
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
                    return environmentFactory.CreateShell(this.RowPosition + 1, this.ColumnPosition, this.Map, this.Direction, this.environmentFactory, this.Collision);
                case Direction.Left:
                    return environmentFactory.CreateShell(this.RowPosition, this.ColumnPosition - 1, this.Map, this.Direction, this.environmentFactory, this.Collision);
                case Direction.Right:
                    return environmentFactory.CreateShell(this.RowPosition, this.ColumnPosition + 1, this.Map, this.Direction, this.environmentFactory, this.Collision);
                default:
                    return environmentFactory.CreateShell(this.RowPosition - 1, this.ColumnPosition, this.Map, this.Direction, this.environmentFactory, this.Collision);
            }
        }
    }
}

