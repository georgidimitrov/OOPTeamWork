using AlphaTank.DisplayControl;
using System;
using System.Threading;
using System.Windows.Input;

namespace AlphaTank.Program
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            MainMenu.Instance.Run();
        }
    }
}
