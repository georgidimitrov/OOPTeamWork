using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Logic.Contracts;
using Autofac;
using AlphaTank.Program.GameEngine.TimerProvider;
using Autofac.Core;
using System.Collections.Generic;

namespace AlphaTank.Program.Factories
{
    public class EnvironmentFactory : IEnvironmentFactory
    {
        private readonly IComponentContext container;

        public EnvironmentFactory(IComponentContext container)
        {
            this.container = container;
        }

        public IEnemyTank CreateEnemyTank(int row, int col, Direction direction)
        {
            var parameters = new List<Parameter>
            {
                new NamedParameter("row", row),
                new NamedParameter("col", col),
                new NamedParameter("direction", direction)
            };

            return container.Resolve<IEnemyTank>(parameters);
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
