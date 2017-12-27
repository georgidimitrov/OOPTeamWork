using AlphaTank.Program.Display;
using System;

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
