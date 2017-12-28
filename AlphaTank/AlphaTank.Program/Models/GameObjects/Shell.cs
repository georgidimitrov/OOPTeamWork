using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Models.GameObjects
{
    public class Shell : GameObject, IMovable
    {
        private readonly Map map;
        private readonly string direction;

        public Shell(int row, int col, Map map, string direction) : base(row, col)
        {
            this.map = map;
            this.direction = direction;
            this.Spawn();
        }

        public void Spawn()
        {
            if (this.map.GetMap[this.RowPosition, this.ColumnPosition] is Tank)
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition,this.ColumnPosition);
            }
            else if (this.map.GetMap[this.RowPosition, this.ColumnPosition] is Obstacle)
            {

            }
            else
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = this;
            }
        }
        public void Move()
        {
            switch (direction)
            {
                case "Up":
                    this.MoveUp();
                    break;
                case "Down":
                    this.MoveDown();
                    break;
                case "Left":
                    this.MoveLeft();
                    break;
                case "Right":
                    this.MoveRight();
                    break;
                default:
                    break;
            }
        }
        public bool MoveDown()
        {
            if (Collision.DetectCollision(this.map, this.RowPosition + 1, this.ColumnPosition))
            {
                if (this.map.GetMap[this.RowPosition + 1,this.ColumnPosition] is PlayerTank)
                {
                    //Game Over
                }
                else if (this.map.GetMap[this.RowPosition + 1, this.ColumnPosition] is EnemyTank)
                {
                    map.GetMap[this.RowPosition + 1, this.ColumnPosition] = new Road(this.RowPosition + 1, this.ColumnPosition);
                }
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveLeft()
        {
            if (Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition - 1))
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition - 1] = this;
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
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
            if (Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition + 1))
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition + 1] = this;
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
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
            if (Collision.DetectCollision(this.map, this.RowPosition - 1, this.ColumnPosition))
            {
                this.map.GetMap[this.RowPosition - 1, this.ColumnPosition] = this;
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.RowPosition--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
