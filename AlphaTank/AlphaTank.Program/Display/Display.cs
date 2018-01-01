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

        public void Update(Map map, int oldX, int oldY, int newX, int newY, char representative)
        {
            Console.SetCursorPosition(oldY, oldX);
            Console.Write(' ');

            Console.SetCursorPosition(newY, newX);
            Console.Write(representative);
        }
    }
}
