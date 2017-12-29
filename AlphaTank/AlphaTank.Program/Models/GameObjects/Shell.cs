using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;

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
            if (this.map.GetMov[this.RowPosition, this.ColumnPosition] is Tank)
            {
                this.map.Get[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                this.map.GetMov[this.RowPosition, this.ColumnPosition] = null;
            }
            else if (this.map.Get[this.RowPosition, this.ColumnPosition] is Obstacle)
            {

            }
            else
            {
                this.map.GetMov[this.RowPosition, this.ColumnPosition] = this;
            }
        }

        public void Move()
        {
            switch (Direction)
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
            if (!Collision.DetectCollision(this.map, this.RowPosition + 1, this.ColumnPosition))
            {
                if (this.map.GetMov[this.RowPosition + 1, this.ColumnPosition] is PlayerTank)
                {
                    //Game Over
                }
                else if (this.map.GetMov[this.RowPosition + 1, this.ColumnPosition] is EnemyTank)
                {
                    map.Get[this.RowPosition + 1, this.ColumnPosition] = new Road(this.RowPosition + 1, this.ColumnPosition);
                    map.GetMov[this.RowPosition + 1, this.ColumnPosition] = null;
                }

                map.Get[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;

                map.GetMov[this.RowPosition + 1, this.ColumnPosition] = this;
                this.RowPosition++;

                return true;
            }
            else
            {
                map.Get[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;
                return false;
            }
        }

        public bool MoveLeft()
        {
            if (!Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition - 1))
            {
                if (this.map.GetMov[this.RowPosition, this.ColumnPosition - 1] is PlayerTank)
                {
                    //Game Over
                }
                else if (this.map.GetMov[this.RowPosition, this.ColumnPosition - 1] is EnemyTank)
                {
                    map.Get[this.RowPosition, this.ColumnPosition - 1] = new Road(this.RowPosition, this.ColumnPosition - 1);
                    map.GetMov[this.RowPosition, this.ColumnPosition - 1] = null;
                }

                map.Get[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;

                map.GetMov[this.RowPosition, this.ColumnPosition - 1] = this;
                this.ColumnPosition--;
                return true;
            }
            else
            {
                map.Get[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;
                return false;
            }
        }

        public bool MoveRight()
        {
            if (!Collision.DetectCollision(this.map, this.RowPosition, this.ColumnPosition + 1))
            {
                if (this.map.GetMov[this.RowPosition, this.ColumnPosition + 1] is PlayerTank)
                {
                    //Game Over
                }
                else if (this.map.GetMov[this.RowPosition, this.ColumnPosition + 1] is EnemyTank)
                {
                    map.Get[this.RowPosition, this.ColumnPosition + 1] = new Road(this.RowPosition, this.ColumnPosition + 1);
                    map.GetMov[this.RowPosition, this.ColumnPosition + 1] = null;
                }
                map.Get[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;

                map.GetMov[this.RowPosition, this.ColumnPosition + 1] = this;
                this.ColumnPosition++;

                return true;
            }
            else
            {
                map.Get[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;
                return false;
            }
        }

        public bool MoveUp()
        {
            if (!Collision.DetectCollision(this.map, this.RowPosition - 1, this.ColumnPosition))
            {
                if (this.map.GetMov[this.RowPosition - 1, this.ColumnPosition] is PlayerTank)
                {
                    //Game Over
                }
                else if (this.map.GetMov[this.RowPosition - 1, this.ColumnPosition] is EnemyTank)
                {
                    map.Get[this.RowPosition - 1, this.ColumnPosition] = new Road(this.RowPosition - 1, this.ColumnPosition);
                    map.GetMov[this.RowPosition - 1, this.ColumnPosition] = null;
                }

                map.Get[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;

                map.GetMov[this.RowPosition - 1, this.ColumnPosition] = this;
                this.RowPosition--;

                return true;
            }
            else
            {
                map.Get[this.RowPosition, this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
                map.GetMov[this.RowPosition, this.ColumnPosition] = null;
                return false;
            }
        }
    }
}
