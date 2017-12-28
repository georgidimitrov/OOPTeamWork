using AlphaTank.Program.Display;
using System;

namespace AlphaTank.Program
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Map map = new Map("asda");
           map.PrintMap();
           // Console.CursorVisible = false;
           // MainMenu.Instance.Run();
        }
    }
}
