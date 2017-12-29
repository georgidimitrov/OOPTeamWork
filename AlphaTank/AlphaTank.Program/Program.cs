using AlphaTank.Program.Display;
using AlphaTank.Program.Models.GameObjects;
using AlphaTank.Program.Engine;
using System;

namespace AlphaTank.Program
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Engine.Engine.Instance.Start();
        }
    }
}
