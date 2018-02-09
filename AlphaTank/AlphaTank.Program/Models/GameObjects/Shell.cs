using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
using System;
using System.Threading;

namespace AlphaTank.Program.Models.GameObjects
{
    public class Shell : GameObject, IShell, IMovableGameObject
    {
        private readonly Direction direction;
        private readonly IEnvironmentFactory environmentFactory;
        private readonly ICollision collision;

        public Shell(int row, int col, IMap map, Direction direction, IEnvironmentFactory environmentFactory, ICollision collision) : base(row, col, map)
        {
            this.Representative = '+';
            this.Color = ConsoleColor.DarkRed;
            this.direction = direction;

            this.environmentFactory = environmentFactory ?? throw new ArgumentNullException();
            this.collision = collision ?? throw new ArgumentNullException();

            this.Spawn();
        }

        public Direction Direction => this.direction;

        private void Spawn()
        {
            if (this.Map[this.RowPosition, this.ColumnPosition] is ITank || this.Map[this.RowPosition, this.ColumnPosition] is IShell)
            {
                this.Map[this.RowPosition, this.ColumnPosition].Destroy();
                this.Map[this.RowPosition, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition, this.Map);
                this.Destroy();
            }
            else if (this.Map[this.RowPosition, this.ColumnPosition] is IIndestructable)
            {
                this.Destroy();
            }
            else if (this.Map[this.RowPosition, this.ColumnPosition] is INonObstacle)
            {
                this.Map[this.RowPosition, this.ColumnPosition] = this;
            }
        }

        public bool Move()
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
            return false;
        }

        public bool MoveDown()
        {
            Map[this.RowPosition, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition, this.Map);
            if (this.collision.DetectCollision(this.Map, this.RowPosition + 1, this.ColumnPosition))
            {
                IGameObject gameObject = this.Map[this.RowPosition + 1, this.ColumnPosition];
                if (gameObject is IIndestructable)
                {
                    this.Destroy();
                    return true;
                }
                this.Map[this.RowPosition + 1, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition + 1, this.ColumnPosition, this.Map);
                this.Destroy();
                gameObject.Destroy();
                return true;
            }
            else
            {
                Map[this.RowPosition + 1, this.ColumnPosition] = this;
                this.RowPosition++;
                return false;
            }
        }

        public bool MoveLeft()
        {
            Map[this.RowPosition, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition, this.Map);
            if (this.collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition - 1))
            {
                IGameObject gameObject = this.Map[this.RowPosition, this.ColumnPosition - 1];

                if (gameObject is IIndestructable)
                {
                    this.Destroy();
                    return true;
                }
                this.Map[this.RowPosition, this.ColumnPosition - 1] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition - 1, this.Map);
                this.Destroy();
                gameObject.Destroy();
                return true;
            }
            else
            {
                Map[this.RowPosition, this.ColumnPosition - 1] = this;
                this.ColumnPosition--;
                return false;
            }
        }

        public bool MoveRight()
        {
            Map[this.RowPosition, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition, this.Map);
            if (this.collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition + 1))
            {
                IGameObject gameObject = this.Map[this.RowPosition, this.ColumnPosition + 1];
                if (gameObject is IIndestructable)
                {
                    this.Destroy();
                    return true;
                }
                Map[this.RowPosition, this.ColumnPosition + 1] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition + 1, this.Map);
                this.Destroy();
                gameObject.Destroy();
                return true;
            }
            else
            {
                Map[this.RowPosition, this.ColumnPosition + 1] = this;
                this.ColumnPosition++;
                return false;
            }
        }

        public bool MoveUp()
        {
            Map[this.RowPosition, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition, this.ColumnPosition, this.Map);
            if (this.collision.DetectCollision(this.Map, this.RowPosition - 1, this.ColumnPosition))
            {
                IGameObject gameObject = this.Map[this.RowPosition - 1, this.ColumnPosition];

                if (gameObject is IIndestructable)
                {
                    this.Destroy();
                    return true;
                }
                Map[this.RowPosition - 1, this.ColumnPosition] = environmentFactory.CreateRoad(this.RowPosition - 1, this.ColumnPosition, this.Map);
                this.Destroy();
                gameObject.Destroy();
                return true;
            }
            else
            {
                Map[this.RowPosition - 1, this.ColumnPosition] = this;
                this.RowPosition--;
                return false;
            }
        }
    }

}
