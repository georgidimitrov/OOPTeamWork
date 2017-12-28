using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    class PlayerTank : Tank
    {
        public PlayerTank(int row, int col, Map map) : base(row, col, map)
        {
            this.Representative = '@';
        }
    }
}
