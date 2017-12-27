using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Models.GameObjects
{
    class Obstacle : GameObject
    {
        private readonly char representative = 'X'; 
        public Obstacle(int row, int col) : base(row, col)
        {
        }
    }
}
