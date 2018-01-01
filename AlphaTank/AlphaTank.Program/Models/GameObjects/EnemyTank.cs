using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Models.GameObjects
{
    class EnemyTank : Tank, IEnemy
    {
        private readonly PlayerTank playerTank;
        private Map map;


        public EnemyTank(int row, int col, Map map, PlayerTank playerTank) : base(row, col, map)
        {
            this.Type = GameObjectType.EnemyTank;
            this.Color = ConsoleColor.Red;
            this.map = map;
            this.playerTank = playerTank;
        }

        public void Move()
        {

        }
        public void TryToKill(PlayerTank playerTank)
        {

        }
        private void DetectPlayer(int playerRow, int playerColumn)
        {
            if (playerRow == this.RowPosition && IsRowClean())
            {

            }
            else if (playerColumn == this.ColumnPosition && IsColumnClean(playerRow))
            {
                if (playerRow > this.RowPosition)
                {
                    this.Direction = Direction.Down;
                    this.Shoot();
                }
                else
                {
                    this.Direction = Direction.Up;
                    this.Shoot();
                }
            }
        }

        private bool IsColumnClean(int playerRow)
        {
            if (this.RowPosition > playerRow)
            {
                for (int i = this.RowPosition - 1; i > playerRow; i--)
                {
                    if (Collision.DetectCollision(this.map, i, this.ColumnPosition))
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
                    if (Collision.DetectCollision(this.map, i, this.ColumnPosition))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
