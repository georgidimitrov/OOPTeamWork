using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Models.Contracts
{
    interface IEnemy
    {
        void DetectPlayer(PlayerTank playerTank);
        void Move();
    }
}
