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
            this.map.GetMov[base.RowPosition, base.ColumnPosition] = this;
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
            throw new NotImplementedException();
        }

        public bool MoveDown()
        {
            this.Direction = "Down";
            if (!Collision.DetectCollision(this.map, this.RowPosition + 1, this.ColumnPosition))
            {
                map.GetMov[this.RowPosition + 1, this.ColumnPosition] = this;
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;
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
                map.GetMov[this.RowPosition, this.ColumnPosition - 1] = this;
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;
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
                map.GetMov[this.RowPosition, this.ColumnPosition + 1] = this;
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;
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
                map.GetMov[this.RowPosition - 1, this.ColumnPosition] = this;
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;
                this.RowPosition--;
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
                    new Shell(this.RowPosition + 1, this.ColumnPosition, this.map, "Down");
                    break;
                case "Left":
                    new Shell(this.RowPosition, this.ColumnPosition - 1, this.map, "Left");
                    break;
                case "Right":
                    new Shell(this.RowPosition, this.ColumnPosition + 1, this.map, "Right");
                    break;
                case "Up":
                    new Shell(this.RowPosition - 1, this.ColumnPosition, this.map, "Up");
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

