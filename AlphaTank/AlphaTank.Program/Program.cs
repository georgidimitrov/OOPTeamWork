using AlphaTank.Program.GameDisplay;
using AlphaTank.Program.Models.GameObjects;
using AlphaTank.Program.GameEngine;
using System;
using Autofac;
using System.Reflection;

namespace AlphaTank.Program
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var engine = container.Resolve<Engine>();

            engine.Start();
        }
    }
}