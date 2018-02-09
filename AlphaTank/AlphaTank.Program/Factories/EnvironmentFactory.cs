using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Logic.Contracts;

namespace AlphaTank.Program.Factories
{
    public class EnvironmentFactory : IEnvironmentFactory
    {
        public IEnemyTank CreateEnemyTank(int row, int col, IMap map, IPlayerTank playerTank, IEnvironmentFactory factory, ICollision collision)
        {
            return new EnemyTank(row, col, map, playerTank, factory, collision);
        }

        public IGameObject CreateRoad(int row, int col)
        {
            return new Road(row, col);
        }

        public IShell CreateShell(int row, int col, IMap map, Direction direction, IEnvironmentFactory factory, ICollision collision)
        {
            return new Shell(row, col, map, direction, factory, collision);
        }
    }
}
