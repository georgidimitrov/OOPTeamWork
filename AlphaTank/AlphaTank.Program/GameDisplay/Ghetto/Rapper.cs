using AlphaTank.Program.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Display.Ghetto
{
    public class Rapper : IRapper
    {
        public ConsoleColor ForegroundColor { set { Console.ForegroundColor = value; } }

        public void SetCursorPosition(int a, int b)
        {
            Console.SetCursorPosition(a, b);
        }

        public void Write(string str)
        {
            Console.Write(str);
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
