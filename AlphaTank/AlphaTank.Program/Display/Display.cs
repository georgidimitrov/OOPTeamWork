using AlphaTank.Program.Models;
using System;

namespace AlphaTank.Program.Display
{
    public class Display
    {
        //Fields
        private static readonly Display instance = new Display();

        //Ctors
        private Display() { }

        //Props
        public static Display Instance { get { return instance; } }


        //Methods
        public void Resize(int rowsSize, int colSize)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(colSize, rowsSize);
            Console.SetBufferSize(colSize, rowsSize);
        }

        public void Print(Map map)
        {
            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < map.GetMap.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < map.GetMap.GetLength(1); col++)
                {
                    Console.ForegroundColor = map.GetMap[row, col].Color;
                    Console.Write(map.GetMap[row, col].Representative);
                }
            }
        }

        public void Update(Map map, int oldX, int oldY, int newX, int newY/*, char representative*/)
        {
            Console.SetCursorPosition(oldY, oldX);
            Console.ForegroundColor = map.GetMap[oldX, oldY].Color;
            Console.Write(map.GetMap[oldX, oldY].Representative/*' '*/);

            Console.SetCursorPosition(newY, newX);
            Console.ForegroundColor = map.GetMap[newX, newY].Color;
            Console.Write(map.GetMap[newX, newY].Representative/*representative*/);
        }
    }
}
