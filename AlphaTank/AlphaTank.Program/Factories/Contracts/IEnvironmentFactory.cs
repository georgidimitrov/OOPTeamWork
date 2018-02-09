using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Factories.Contracts
{
    public interface IEnvironmentFactory
    {
        IShell CreateShell(int row, int col, IMap map, Direction direction, IEnvironmentFactory environmentFactory, ICollision collision);
        INonObstacle CreateRoad(int row, int col);
        IEnemyTank CreateEnemyTank(int row, int col, IMap map, IPlayerTank playerTank, IEnvironmentFactory factory, ICollision collision);
        IObstacle CreateObstacle(int row, int col);
    }
}
