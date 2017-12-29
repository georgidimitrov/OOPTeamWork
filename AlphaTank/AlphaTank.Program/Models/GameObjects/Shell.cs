using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using System;
using System.Threading;

namespace AlphaTank.Program.Models.GameObjects
{
    public class Shell : GameObject, IMovableGameObject
    {
        private readonly Map map;
        private readonly string direction;

        public Shell(int row, int col, Map map, string direction) : base(row, col)
        {
            this.Representative = '*';
            this.map = map;
            this.direction = direction;
            this.Spawn();
        }

        public string Direction => direction;

        public void Spawn()
        {
            if (this.map.GetMap[this.RowPosition, this.ColumnPosition] is Tank)
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            }
            else
            {
                this.map.GetMap[this.RowPosition, this.ColumnPosition] = this;
            }
        }

        public bool Move()
        {
                switch (Direction)
                {
                    case "Up":
                        return this.MoveUp();
                        break;
                    case "Down":
                        return this.MoveDown();
                        break;
                    case "Left":
                        return this.MoveLeft();
                        break;
                    case "Right":
                        return this.MoveRight();
                        break;
                    default:
                        return false;
            }
            return false;
        }

        public bool MoveDown()
        {
            if (Collision.DetectCollision(this.map, this.RowPosition + 1, this.ColumnPosition))
            {
                if (this.map.GetMap[this.RowPosition + 1, this.ColumnPosition] is PlayerTank)
                {
                    Thread.Sleep(1000);
                }
                else if (this.map.GetMap[this.RowPosition + 1, this.ColumnPosition] is EnemyTank)
                {
                    map.GetMap[this.RowPosition + 1, this.ColumnPosition] = new Road(this.RowPosition + 1, this.ColumnPosition);
                }
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                
                return false;
            }
            else
            {
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMap[this.RowPosition + 1, this.ColumnPosition] = this;
                this.RowPosition++;
                return true;
            }
        }

        public bool MoveLeft()
        {
            if (Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition - 1))
            {
                if (this.map.GetMap[this.RowPosition, this.ColumnPosition - 1] is PlayerTank)
                {
                    Thread.Sleep(1000);
                    //Game Over
                }
                else if (this.map.GetMap[this.RowPosition, this.ColumnPosition - 1] is EnemyTank)
                {
                    map.GetMap[this.RowPosition, this.ColumnPosition - 1] = new Road(this.RowPosition, this.ColumnPosition - 1);
                }
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                return false;
            }
            else
            {
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMap[this.RowPosition, this.ColumnPosition - 1] = this;
                this.ColumnPosition--;
                return true;
            }
        }

        public bool MoveRight()
        {
            if (Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition + 1))
            {
                if (this.map.GetMap[this.RowPosition, this.ColumnPosition + 1] is PlayerTank)
                {
                    Thread.Sleep(1000);
                    //Game Over
                }
                else if (this.map.GetMap[this.RowPosition, this.ColumnPosition + 1] is EnemyTank)
                {
                    map.GetMap[this.RowPosition, this.ColumnPosition + 1] = new Road(this.RowPosition, this.ColumnPosition - 1);
                }
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                
                return false;
            }
            else
            {
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMap[this.RowPosition, this.ColumnPosition + 1] = this;
                this.ColumnPosition++;
                return true;
            }
        }

        public bool MoveUp()
        {
            if (Collision.DetectCollision(this.map, this.RowPosition - 1, this.ColumnPosition))
            {
                if (this.map.GetMap[this.RowPosition - 1, this.ColumnPosition] is PlayerTank)
                {
                    Thread.Sleep(1000);
                }
                else if (this.map.GetMap[this.RowPosition - 1, this.ColumnPosition] is EnemyTank)
                {
                    map.GetMap[this.RowPosition - 1, this.ColumnPosition] = new Road(this.RowPosition - 1, this.ColumnPosition);
                }
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                return false;
            }
            else
            {
                map.GetMap[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMap[this.RowPosition - 1, this.ColumnPosition] = this;
                this.RowPosition--;
                return true;
            }
        }
    }
}
