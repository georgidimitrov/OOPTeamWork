using AlphaTank.Program.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.GameEngine.DataProvider
{
    public interface IData
    {
        List<IShell> Shells { get; }

        List<IEnemyTank> EnemyTanks { get; }
    }
}
