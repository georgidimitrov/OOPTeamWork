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
            builder.RegisterType<GameDisplay.Display>().As<IDisplay>().SingleInstance();
            builder.RegisterType<KeyboardWraper>().As<IKeyboardWraper>();
            builder.RegisterType<GameTimer>().As<IGameTimer>().SingleInstance();

            ICollection<Parameter> gameSettingsParameters = new List<Parameter>();
            gameSettingsParameters.Add(new NamedParameter("rowsSize", 21));
            gameSettingsParameters.Add(new NamedParameter("colsSize", 30));
            gameSettingsParameters.Add(new NamedParameter("refreshRate", new TimeSpan(0, 0, 0, 0, 100)));
            gameSettingsParameters.Add(new NamedParameter("shellCooldown", new TimeSpan(0, 0, 0, 0, 150)));
            gameSettingsParameters.Add(new NamedParameter("shellSpeed", new TimeSpan(0, 0, 0, 0, 50)));
            gameSettingsParameters.Add(new NamedParameter("enemyTankShootCooldown", new TimeSpan(0, 0, 0, 0, 1800)));

            builder.RegisterType<GameSettings>().As<IGameSettings>().WithParameters(gameSettingsParameters).SingleInstance();

            builder.RegisterType<MainMenu>().As<IMainMenu>().SingleInstance();
            builder.RegisterType<Rapper>().As<IRapper>().SingleInstance();
            builder.RegisterType<EnvironmentFactory>().As<IEnvironmentFactory>().SingleInstance();
            builder.RegisterType<Collision>().As<ICollision>().SingleInstance();

            builder.RegisterType<Map>().As<IMap>().WithParameter("directory", "../../GameDisplay/Levels/Level1.txt").SingleInstance();

            ICollection<Parameter> playerTankParams = new List<Parameter>();
            playerTankParams.Add(new NamedParameter("row", 17));
            playerTankParams.Add(new NamedParameter("col", 14));
            playerTankParams.Add(new NamedParameter("direction", Direction.Up));

            builder.RegisterType<PlayerTank>().As<IPlayerTank>().SingleInstance().WithParameters(playerTankParams);
        }
    }
}
