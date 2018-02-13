using AlphaTank.Program.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.GameEngine.DataProvider
{
    public class Data : IData
    {
        private readonly List<IShell> shells;
        private readonly List<IEnemyTank> enemyTanks;
        public Data()
        {
            this.shells = new List<IShell>();
            this.enemyTanks = new List<IEnemyTank>();
        }
        public List<IShell> Shells => this.shells;

        public List<IEnemyTank> EnemyTanks => this.enemyTanks;
    }
}
