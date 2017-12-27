using AlphaTank.DisplayControl.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace AlphaTank.DisplayControl
{
    public class LevelDisplay : IDisplay
    {
        //Fields
        private static readonly LevelDisplay instance = new LevelDisplay();
        private int infoScoreRow = 5;
        private List<int> scores = new List<int>();

        //Ctors
        private LevelDisplay()
        {
            this.Height = 20;
            this.Width = 50;
            this.Display = new char[Height][];
        }

        //Props
        public static LevelDisplay Instance { get { return instance; } }

        public int Height { get; }

        public int Width { get; }

        public char[][] Display { get; private set; }

        public void Run()
        {
            GetDisplayDesign();
            LevelPrint();
            InfoWindowPrint();


            while (true)
            {
                if (!Keyboard.IsKeyUp(Key.A))
                {
                    break;
                }
            }

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

        private void GetDisplayDesign()
        {
            StreamReader read = new StreamReader(@"C:\Users\Gosho\source\TeamWorkProject\OOPTeamWork\AlphaTank\AlphaTank.DisplayControl\Levels\Level1.txt");

            for (int row = 0; row < Height; row++)
            {
                Display[row] = read.ReadLine().ToCharArray();
            }

            read.Close();
        }

        private void LevelPrint()
        {
            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Console.Write(Display[row][col]);
                }
            }
        }
    }
}
