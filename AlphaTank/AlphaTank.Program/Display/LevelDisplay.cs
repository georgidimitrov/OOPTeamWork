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
    public class LevelDisplay : IMap
    {
        //Fields
        private static readonly LevelDisplay instance = new LevelDisplay();
        private int infoScoreRow = 5;
        private List<int> scores = new List<int>();

        //Ctors
        private LevelDisplay()
        {
            this.MapHeight = 18;
            this.MapWidth = 28;
        }

        //Props
        public static LevelDisplay Instance { get { return instance; } }


        public int MapHeight { get; }

        public int MapWidth { get; }

        public Map Map { get; private set; }

        public PlayerTank MyTank { get; }

        //Methods
        public void Run()
        {
            PrintDisplay();
            InfoWindowPrint();
        }

        private void UpdateDisplay(int row, int col, string dir)
        {
            switch (dir)
            {
                case "Up":
                    Console.SetCursorPosition(col, row);
                    Console.Write(Map.GetMap[row, col].Representative);

                    Console.SetCursorPosition(col, row + 1);
                    Console.Write(Map.GetMap[row + 1, col].Representative);
                    break;
                case "Right":
                    Console.SetCursorPosition(col, row);
                    Console.Write(Map.GetMap[row, col].Representative);

                    Console.SetCursorPosition(col - 1, row);
                    Console.Write(Map.GetMap[row, col - 1].Representative);
                    break;
                case "Down":
                    Console.SetCursorPosition(col, row);
                    Console.Write(Map.GetMap[row, col].Representative);

                    Console.SetCursorPosition(col, row - 1);
                    Console.Write(Map.GetMap[row - 1, col].Representative);
                    break;
                case "Left":
                    Console.SetCursorPosition(col, row);
                    Console.Write(Map.GetMap[row, col].Representative);

                    Console.SetCursorPosition(col + 1, row);
                    Console.Write(Map.GetMap[row, col + 1].Representative);
                    break;
                default:
                    break;
            }

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
    }
}
