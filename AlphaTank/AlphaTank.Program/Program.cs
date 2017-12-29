using AlphaTank.Program.Display;
using AlphaTank.Program.Models.GameObjects;
using System;

namespace AlphaTank.Program
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.SetWindowSize(50, 21);
            Console.SetBufferSize(50, 21);
            Console.CursorVisible = false;

            MainMenu.Instance.Run();
        }
    }
}
