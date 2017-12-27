using AlphaTank.Program.Display.Contracts;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace AlphaTank.Program.Display
{
    public class LevelDisplay : IDisplay, IMap
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

            this.MapHeight = 18;
            this.MapWidth = 28;
            this.Map = new IGameObject[Height][];

            this.MyTank = new PlayerTank(17, 13);
        }

        //Props
        public static LevelDisplay Instance { get { return instance; } }

        public int Height { get; }

        public int Width { get; }

        public char[][] Display { get; private set; }


        public int MapHeight { get; }

        public int MapWidth { get; }

        public IGameObject[][] Map { get; private set; }

        public PlayerTank MyTank { get; }

        //Methods
        public void Run()
        {
            GetDisplayDesign();
            LevelPrint();
            InfoWindowPrint();
            GetMap();
            PlayGame();
        }

        private void PlayGame()
        {
            DateTime dt = DateTime.Now;

            this.Display[MyTank.RowPosition + 1][MyTank.ColumnPosition + 1] = MyTank.Representative;
            this.Map[MyTank.RowPosition][MyTank.ColumnPosition] = MyTank;

            Console.SetCursorPosition(MyTank.ColumnPosition + 1, MyTank.RowPosition + 1);
            Console.Write(this.Display[MyTank.RowPosition + 1][MyTank.ColumnPosition + 1]);

            while (true)
            {
                TimeSpan elapsed = DateTime.Now - dt;

                if (elapsed.Milliseconds > 100)
                {
                    if (!Keyboard.IsKeyUp(Key.Up))
                    {
                        MyTank.MoveUp(Map, Display);
                    }
                    else if (!Keyboard.IsKeyUp(Key.Right))
                    {
                        MyTank.MoveRight(Map, Display);
                    }
                    else if (!Keyboard.IsKeyUp(Key.Down))
                    {
                        MyTank.MoveDown(Map, Display);
                    }
                    else if (!Keyboard.IsKeyUp(Key.Left))
                    {
                        MyTank.MoveLeft(Map, Display);
                    }

                    dt = DateTime.Now;
                }
            }
        }

        private void GetDisplayDesign()
        {
            StreamReader read = new StreamReader(@"C:\Users\Dimitar Petrow\source\repos\OOPTeamWork\AlphaTank\AlphaTank.Program\Display\Levels\Level1.txt");

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

        private void GetMap()
        {
            for (int row = 1, mapRow = 0; row < 1 + MapHeight; row++, mapRow++)
            {
                this.Map[mapRow] = new IGameObject[MapWidth];

                for (int col = 1, mapCol = 0; col < MapWidth + 1; col++, mapCol++)
                {
                    if (Display[row][col] != ' ')
                    {
                        Map[mapRow][mapCol] = new Obstacle(mapRow, mapCol);
                    }
                    else
                    {
                        Map[mapRow][mapCol] = new Road(mapRow, mapCol);
                    }
                }
            }
        }
    }
}
