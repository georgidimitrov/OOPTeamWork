 using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using System;
using System.Threading;

namespace AlphaTank.Program.Models.GameObjects
{
    public class Shell : GameObject, IShell, IMovableGameObject
    {
        private readonly Direction direction;

        public Shell(int row, int col, IMap map, Direction direction) : base(row, col)
        {
            this.Representative = '+';
            this.Color = ConsoleColor.DarkRed;
            this.Map = map;
            this.direction = direction;
            this.Spawn();
        }

        public Direction Direction => this.direction;

        private void Spawn()
        {
            if (this.Map[this.RowPosition, this.ColumnPosition] is Tank || this.Map[this.RowPosition, this.ColumnPosition] is Shell)
            {
                this.Map[this.RowPosition, this.ColumnPosition].Destroy();
                this.Map[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.Destroy();
            }
            else if (this.Map[this.RowPosition, this.ColumnPosition] is Obstacle)
            {
                this.Destroy();
            }
            else if (this.Map[this.RowPosition, this.ColumnPosition] is Road)
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
            this.IsThereAMap();
            Map[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.Map, this.RowPosition + 1, this.ColumnPosition))
            {
                IGameObject gameObject = this.Map[this.RowPosition + 1, this.ColumnPosition];
                if (gameObject is Obstacle)
                {
                    this.Destroy();
                    return true;
                }
                this.Map[this.RowPosition + 1, this.ColumnPosition] = new Road(this.RowPosition + 1, this.ColumnPosition);
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
            this.IsThereAMap();
            Map[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition - 1))
            {
                IGameObject gameObject = this.Map[this.RowPosition, this.ColumnPosition - 1];

                if (gameObject is Obstacle)
                {
                    this.Destroy();
                    return true;
                }
                this.Map[this.RowPosition, this.ColumnPosition - 1] = new Road(this.RowPosition, this.ColumnPosition - 1);
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
            this.IsThereAMap();
            Map[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.Map, this.RowPosition, this.ColumnPosition + 1))
            {
                IGameObject gameObject = this.Map[this.RowPosition, this.ColumnPosition + 1];
                if (gameObject is Obstacle)
                {
                    this.Destroy();
                    return true;
                }
                Map[this.RowPosition, this.ColumnPosition + 1] = new Road(this.RowPosition, this.ColumnPosition + 1);
                this.Destroy();
                gameObject.Destroy();
                return true;
            }
            else
            {
                Map[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                Map[this.RowPosition, this.ColumnPosition + 1] = this;
                this.ColumnPosition++;
                return false;
            }
        }

        public bool MoveUp()
        {
            this.IsThereAMap();
            Map[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            if (Collision.DetectCollision(this.Map, this.RowPosition - 1, this.ColumnPosition))
            {
                IGameObject gameObject = this.Map[this.RowPosition - 1, this.ColumnPosition];

                if (gameObject is Obstacle)
                {
                    this.Destroy();
                    return true;
                }
                Map[this.RowPosition - 1, this.ColumnPosition] = new Road(this.RowPosition - 1, this.ColumnPosition);
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

        public void IsThereAMap()
        {
            if (this.Map == null)
            {
                throw new NoMapException("No map to move shell in.");
            }
        }
    }

}
