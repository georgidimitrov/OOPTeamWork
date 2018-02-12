using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AlphaTank.Program.GameEngine;
using AlphaTank.Program.Contracts;
using AlphaTank.Program.GameDisplay;
using AlphaTank.Program.Display.Ghetto;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.GameObjects;
using Autofac.Core;
using AlphaTank.Program.Factories;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.GameEngine.ControlProvider;
using AlphaTank.Program.GameEngine.TimerProvider;

namespace AlphaTank.Program.Injections
{
    internal class DIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().AsSelf().SingleInstance();

            RegisterProviders(builder);
            RegisterGameSettings(builder);
            RegisterModels(builder);
        }

        private static void RegisterProviders(ContainerBuilder builder)
        {
            builder.RegisterType<KeyboardWraper>().As<IKeyboardWraper>();
            builder.RegisterType<GameTimer>().As<IGameTimer>();
            builder.RegisterType<EnvironmentFactory>().As<IEnvironmentFactory>().SingleInstance();
            builder.RegisterType<Collision>().As<ICollision>().SingleInstance();
            builder.RegisterType<Rapper>().As<IRapper>().SingleInstance();

            builder.RegisterType<GameDisplay.Display>().As<IDisplay>().SingleInstance();
            builder.RegisterType<MainMenu>().As<IMainMenu>().SingleInstance();
        }

        private static void RegisterGameSettings(ContainerBuilder builder)
        {
            ICollection<Parameter> gameSettingsParameters = new List<Parameter>
            {
                new NamedParameter("rowsSize", 21),
                new NamedParameter("colsSize", 30),
                new NamedParameter("refreshRate", new TimeSpan(0, 0, 0, 0, 200)),
                new NamedParameter("shellCooldown", new TimeSpan(0, 0, 0, 0, 300)),
                new NamedParameter("shellSpeed", new TimeSpan(0, 0, 0, 0, 100)),
                new NamedParameter("enemyTankShootCooldown", new TimeSpan(0, 0, 0, 0, 1800))
            };
            builder.RegisterType<GameSettings>().As<IGameSettings>().WithParameters(gameSettingsParameters);
        }

        private static void RegisterModels(ContainerBuilder builder)
        {
            //PlayerTank
            ICollection<Parameter> playerTankParams = new List<Parameter>();
            playerTankParams.Add(new NamedParameter("row", 17));
            playerTankParams.Add(new NamedParameter("col", 14));
            playerTankParams.Add(new NamedParameter("direction", Direction.Up));
            builder.RegisterType<PlayerTank>().As<IPlayerTank>().SingleInstance().WithParameters(playerTankParams);

            //EnemyTank
            ICollection<Parameter> enemyTankParams = new List<Parameter>();
            enemyTankParams.Add(new ResolvedParameter(
                (pi, ctx) => pi.Name == "map",
                (pi, ctx) => ctx.Resolve<IMap>()));
            enemyTankParams.Add(new ResolvedParameter(
                (pi, ctx) => pi.Name == "playerTank",
                (pi, ctx) => ctx.Resolve<IPlayerTank>()));
            enemyTankParams.Add(new ResolvedParameter(
                (pi, ctx) => pi.Name == "environmentFactory",
                (pi, ctx) => ctx.Resolve<IEnvironmentFactory>()));
            enemyTankParams.Add(new ResolvedParameter(
                (pi, ctx) => pi.Name == "collision",
                (pi, ctx) => ctx.Resolve<ICollision>()));
            enemyTankParams.Add(new ResolvedParameter(
                (pi, ctx) => pi.Name == "gameTimer",
                (pi, ctx) => ctx.Resolve<IGameTimer>()));
            builder.RegisterType<EnemyTank>().As<IEnemyTank>().WithParameters(enemyTankParams);

            //Map
            builder.RegisterType<Map>().As<IMap>().WithParameter("directory", "../../GameDisplay/Levels/Level1.txt").SingleInstance();
        }
    }
}
