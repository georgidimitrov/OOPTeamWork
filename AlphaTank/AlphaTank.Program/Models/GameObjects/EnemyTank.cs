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
        public EnemyTank(int row, int col, Map map) : base(row, col, map)
        {
        }

        public void DetectPlayer(PlayerTank playerTank)
        {
            if (playerTank.RowPosition == this.RowPosition)
            {

            }
            if (playerTank.ColumnPosition == this.ColumnPosition)
            {

            }
        }

        public void Move()
        {
            
        }
    }
}
