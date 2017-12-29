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
        private int infoScoreRow = 5;
        private List<int> scores = new List<int>();

        //Ctors
        private Display()
        {
        }

        //Props
        public static Display Instance { get { return instance; } }

        public Map Map { get; private set; }

        public PlayerTank MyTank { get; }


        //Methods
        public void Run()
        {
            PrintDisplay();
            InfoWindowPrint();
        }

        private void PrintDisplay()
        {
            StreamReader read = new StreamReader("../../Display/Levels/Level1.txt");

            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < Console.BufferHeight - 1; row++)
            {
                Console.Write(read.ReadLine());
            }

            read.Close();

            Console.SetCursorPosition(MyTank.ColumnPosition, MyTank.RowPosition);
            Console.Write(MyTank.Representative);
        }

        private void InfoWindowPrint()
        {
            if (infoScoreRow == 17)
            {
                infoScoreRow = 5;
                scores.Clear();
                ClearScoreBoard();
            }
            for (int s = 0; s < scores.Count; s++)
            {
                Console.SetCursorPosition(35, infoScoreRow - (scores.Count - s));
                Console.Write((s + 1) + ". " + scores[s]);

            }

            Console.SetCursorPosition(35, infoScoreRow);
            Console.Write(infoScoreRow - 4 + ". " + 100);
            scores.Add(100);
            infoScoreRow++;
        }

        private void ClearScoreBoard()
        {
            for (int r = 4; r <= 17; r++)
            {
                Console.SetCursorPosition(31, r);
                Console.Write("                  ");
            }
        }

        public void Resize()
        {
            Console.CursorVisible = false;
            Console.SetBufferSize(30, 21);
            Console.SetWindowSize(30, 21);
        }
    }
}
