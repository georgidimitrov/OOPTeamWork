using AlphaTank.Program.Display.Contracts;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace AlphaTank.Program.Display
{
    public class Display
    {
        //Fields
        private static readonly Display instance = new Display();

        //Ctors
        private Display()
        {
        }

        //Props
        public static Display Instance { get { return instance; } }


        //Methods
        public void Resize()
        {
            Console.CursorVisible = false;
            Console.SetBufferSize(30, 21);
            Console.SetWindowSize(30, 21);
        }

        public void Print(Map map)
        {
            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < map.GetMap.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < map.GetMap.GetLength(1); col++)
                {
                    if (map.GetMap[row, col] is PlayerTank)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(map.GetMap[row, col].Representative);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (map.GetMap[row, col] is Shell)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(map.GetMap[row, col].Representative);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(map.GetMap[row, col].Representative);
                    }
                }
            }
        }

    }
}
