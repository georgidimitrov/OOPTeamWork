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

namespace AlphaTank.Program.Injections
{
    internal class DIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().AsSelf().SingleInstance();
            builder.RegisterType<GameDisplay.Display>().As<IDisplay>().SingleInstance();
            builder.RegisterType<MainMenu>().As<IMainMenu>().SingleInstance();
            builder.RegisterType<Rapper>().As<IRapper>().SingleInstance();
            builder.RegisterType<Map>().As<IMap>().SingleInstance().WithParameter("directory", "../../GameDisplay/Levels/Level1.txt");

            ICollection<Parameter> playerTankParams = new List<Parameter>();
            playerTankParams.Add(new NamedParameter("row", 17));
            playerTankParams.Add(new NamedParameter("col", 14));

            builder.RegisterType<PlayerTank>().As<IPlayerTank>().SingleInstance().WithParameters(playerTankParams);
        }
    }
}
