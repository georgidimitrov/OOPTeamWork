using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Enums_and_Structs;
using System;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;

namespace AlphaTank.Program.Models.GameObjects
{
    class EnemyTank : Tank, IEnemyTank
    {
        private readonly IPlayerTank playerTank;
        private IMap map;
        private TimeSpan cooldown = new TimeSpan(0, 0, 0, 0, 1800);
        private DateTime time;

        public EnemyTank(int row, int col, IMap map, IPlayerTank playerTank, IEnvironmentFactory environmentFactory, ICollision collision) : base(row, col, map, environmentFactory, collision)
        {
            this.Color = ConsoleColor.Red;
            this.map = map;
            this.playerTank = playerTank;
            this.time = DateTime.Now;
        }

        public bool Move()
        {
            int maxTries = 0;
            Random rand = new Random();
            while (maxTries < 100)
            {
                bool change = TryToMove(this.Direction);
                if (change == true)
                {
                    return true;
                }
                else
                {
                    this.Direction = (Direction)Enum.Parse(typeof(Direction), rand.Next(0, 4).ToString());
                }
                maxTries++;
            }
            return false;
        }

        private bool TryToMove(Direction direction)
        {
            switch (direction)
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
            return false;
        }

        public IShell DetectPlayer()
        {

            if (playerTank.RowPosition == this.RowPosition && IsRowClean(playerTank.ColumnPosition) && ShellCooldown())
            {
                if (playerTank.ColumnPosition > this.ColumnPosition)
                {
                    this.Direction = Direction.Right;
                    return this.Shoot();
                }
                else
                {
                    this.Direction = Direction.Left;
                    return this.Shoot();
                }
            }
            else if (playerTank.ColumnPosition == this.ColumnPosition && IsColumnClean(playerTank.RowPosition) && ShellCooldown())
            {
                if (playerTank.RowPosition > this.RowPosition)
                {
                    this.Direction = Direction.Down;
                    return this.Shoot();
                }
                else
                {
                    this.Direction = Direction.Up;
                    return this.Shoot();
                }
            }
            return null;
        }

        private bool ShellCooldown()
        {
            if (this.cooldown < DateTime.Now - this.time)
            {
                this.time = DateTime.Now;
                return true;
            }
            return false;
        }

        private bool IsRowClean(int playerColumn)
        {
            if (this.ColumnPosition > playerColumn)
            {
                for (int i = this.ColumnPosition - 1; i > playerColumn; i--)
                {
                    if (Collision.IsObstacleOrAlly(this.map, this.RowPosition, i))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                for (int i = this.ColumnPosition + 1; i < playerColumn; i++)
                {
                    if (Collision.IsObstacleOrAlly(this.map, this.RowPosition, i))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private bool IsColumnClean(int playerRow)
        {
            if (this.RowPosition > playerRow)
            {
                for (int i = this.RowPosition - 1; i > playerRow; i--)
                {
                    if (Collision.IsObstacleOrAlly(this.map, i, this.ColumnPosition))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                for (int i = this.RowPosition + 1; i < playerRow; i++)
                {
                    if (Collision.IsObstacleOrAlly(this.map, i, this.ColumnPosition))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
