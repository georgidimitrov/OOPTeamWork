using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class Tank : GameObject, ITank, IMovable
    {
        private string direction = "Up";
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
        public string Direction
        {
            get { return this.direction; }
            set
            {
                if (value == "Up" || value == "Down" || value == "Left" || value == "Right")
                {
                    this.direction = value;
                }
                else
                {
                    throw new ArgumentException("Tank direction invalid.");
                }
            }
        }
        public bool MoveDown()
        {
            if (!Collision.DetectCollision(this.map, this.RowPosition + 1, this.ColumnPosition))
            {
                map.GetMap[this.RowPosition + 1, this.ColumnPosition] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
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
            if (!Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition - 1))
            {
                map.GetMap[this.RowPosition, this.ColumnPosition - 1] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.ColumnPosition--;
                direction = "Left";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveRight()
        {
            if (!Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition + 1))
            {
                map.GetMap[this.RowPosition, this.ColumnPosition + 1] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.ColumnPosition++;
                direction = "Right";
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveUp()
        {
            if (!Collision.DetectCollision(this.map, this.RowPosition - 1, this.ColumnPosition))
            {
                map.GetMap[this.RowPosition - 1, this.ColumnPosition] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.RowPosition--;
                direction = "Up";
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Shoot()
        {
            switch (this.Direction)
            {
                case "Down":
                     new Shell(this.RowPosition + 1, this.ColumnPosition, this.map, "down");
                    break;
                case "Left":
                     new Shell(this.RowPosition, this.ColumnPosition - 1, this.map, "left");
                    break;
                case "Right":
                     new Shell(this.RowPosition, this.ColumnPosition + 1, this.map , "right");
                    break;
                case "Up":
                    new Shell(this.RowPosition - 1, this.ColumnPosition, this.map , "up");
                    break;
                default:
                    break;
            }
        }
        public void Destroy()
        {
            Console.WriteLine("Waddup");
        }
    }
}

