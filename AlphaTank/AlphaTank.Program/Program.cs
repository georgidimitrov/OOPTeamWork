using AlphaTank.DisplayControl;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;

namespace AlphaTank.Program
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            MainMenu.Instance.Run();
        }
    }
}
