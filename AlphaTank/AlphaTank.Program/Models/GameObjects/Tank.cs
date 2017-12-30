using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program;
using System;
using AlphaTank.Program.Logic;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class Tank : GameObject, ITank, IMovableGameObject
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
            protected set
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

        public void Move()
        {
        }

        public bool MoveDown()
        {
            this.Direction = "Down";
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
            this.Direction = "Left";
            if (!Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition - 1))
            {
                map.GetMap[this.RowPosition, this.ColumnPosition - 1] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
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
            this.Direction = "Right";
            if (!Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition + 1))
            {
                map.GetMap[this.RowPosition, this.ColumnPosition + 1] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
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
            this.Direction = "Up";
            if (!Collision.DetectCollision(this.map, this.RowPosition - 1, this.ColumnPosition))
            {
                map.GetMap[this.RowPosition - 1, this.ColumnPosition] = this;
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.RowPosition--;
                return true;
            }   
            else
            {
                return false;
            }
        }

        public Shell Shoot()
        {
            switch (this.Direction)
            {
                case "Down":
                    return new Shell(this.RowPosition + 1, this.ColumnPosition, this.map, "Down");
                case "Left":
                    return new Shell(this.RowPosition, this.ColumnPosition - 1, this.map, "Left");
                case "Right":
                    return new Shell(this.RowPosition, this.ColumnPosition + 1, this.map, "Right");
                case "Up":
                    return new Shell(this.RowPosition - 1, this.ColumnPosition, this.map, "Up");
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

