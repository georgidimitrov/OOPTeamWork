using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Logic.Contracts;
using Autofac;

namespace AlphaTank.Program.Factories
{
    public class EnvironmentFactory : IEnvironmentFactory
    {
        public IEnemyTank CreateEnemyTank(int row, int col, Direction direction, IMap map, IPlayerTank playerTank, IEnvironmentFactory factory, ICollision collision)
        {
            return new EnemyTank(row, col, direction, map, playerTank, factory, collision);
        }

        public IObstacle CreateObstacle(int row, int col, IMap map)
        {
            return new Obstacle(row, col, map);
        }

        public INonObstacle CreateRoad(int row, int col, IMap map)
        {
            return new Road(row, col, map);
        }

        public IShell CreateShell(int row, int col, IMap map, Direction direction, IEnvironmentFactory factory, ICollision collision)
        {
            return new Shell(row, col, map, direction, factory, collision);
        }
    }
}
