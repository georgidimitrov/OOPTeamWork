using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    public class PlayerTank : Tank
    {
        public PlayerTank(int row, int col, Map map) : base(row, col, map)
        {
            this.Representative = '^';
        }

        public override char Representative
        {
            get
            {
                switch (this.Direction)
                {
                    case "Up":
                        return '^';
                    case "Right":
                        return '>';
                    case "Down":
                        return 'v';
                    case "Left":
                        return '<';
                }
                return '@';
            }
        }
    }
}
