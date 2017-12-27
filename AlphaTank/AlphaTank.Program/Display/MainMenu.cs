using AlphaTank.Program.Display.Contracts;
using System;
using System.IO;
using System.Windows.Input;

namespace AlphaTank.Program.Display
{
    public class MainMenu : IDisplay
    {
        //Fields
        private static readonly MainMenu instance = new MainMenu();

        private int menu = 1;

        //Ctors
        private MainMenu()
        {
            if (Console.BufferHeight != 21 || Console.BufferWidth != 50)
            {
                throw new ArgumentException("Console Sizes must be (21; 50)!");
            }

            this.Height = 20;
            this.Width = 50;
            this.Display = new char[Height][];
        }

        //Props
        public static MainMenu Instance { get { return instance; } }

        public int Height { get; }
        public int Width { get; }
        public char[][] Display { get; private set; }

        //Methods
        public void Run()
        {
            GetDisplayDesign();
            MainMenuPrint();
            WaitingForPlayer();
        }

        private void WaitingForPlayer()
        {
            DateTime dt = DateTime.Now;

            CursorMenu(1);

            int shellRow = 10;
            int shellCol = 20;

            while (true)
            {
                TimeSpan elapsed = DateTime.Now - dt;

                if (elapsed.Milliseconds > 100)
                {

                    if (!Keyboard.IsKeyUp(Key.Up))
                    {
                        MoveCursor('u');
                    }
                    else if (!Keyboard.IsKeyUp(Key.Down))
                    {
                        MoveCursor('d');
                    }
                    if (!Keyboard.IsKeyUp(Key.Enter))
                    {
                        if (menu == 1)
                        {
                            LevelDisplay.Instance.Run();
                            MainMenuPrint();
                            CursorMenu(1);
                        }
                        else
                        {
                            return;
                        }
                    }

                    Console.SetCursorPosition(shellCol, shellRow);
                    Console.Write(' ');
                    shellCol++;
                    if (shellCol == 48)
                    {
                        shellCol = 20;
                    }
                    Console.SetCursorPosition(shellCol, shellRow);
                    Console.Write('*');

                    dt = DateTime.Now;
                }
            }
        }

        private void CursorMenu(int m)
        {
            switch (m)
            {
                case 1:
                    Console.SetCursorPosition(29, 16);
                    Console.Write(' ');
                    Console.SetCursorPosition(29 + 5, 16);
                    Console.Write(' ');

                    Console.SetCursorPosition(29, 13);
                    Console.Write('>');
                    Console.SetCursorPosition(29 + 6, 13);
                    Console.Write('<');
                    break;
                case 2:
                    Console.SetCursorPosition(29, 13);
                    Console.Write(' ');
                    Console.SetCursorPosition(29 + 6, 13);
                    Console.Write(' ');

                    Console.SetCursorPosition(29, 16);
                    Console.Write('>');
                    Console.SetCursorPosition(29 + 5, 16);
                    Console.Write('<');
                    break;

                default:
                    break;
            }
        }

        private void MoveCursor(char dir)
        {
            switch (dir)
            {
                case 'u':
                    Console.SetCursorPosition(29, 16);
                    Console.Write(' ');
                    Console.SetCursorPosition(29 + 5, 16);
                    Console.Write(' ');

                    Console.SetCursorPosition(29, 13);
                    Console.Write('>');
                    Console.SetCursorPosition(29 + 6, 13);
                    Console.Write('<');

                    menu = 1;

                    break;
                case 'd':
                    Console.SetCursorPosition(29, 13);
                    Console.Write(' ');
                    Console.SetCursorPosition(29 + 6, 13);
                    Console.Write(' ');


                    Console.SetCursorPosition(29, 16);
                    Console.Write('>');
                    Console.SetCursorPosition(29 + 5, 16);
                    Console.Write('<');

                    menu = 2;

                    break;

                default:
                    break;
            }
        }

        private void GetDisplayDesign()
        {
            StreamReader read = new StreamReader(@"C:\Users\Dimitar Petrow\source\repos\OOPTeamWork\AlphaTank\AlphaTank.Program\Display\MainMenu\MainMenu.txt");

            for (int row = 0; row < Height; row++)
            {
                Display[row] = read.ReadLine().ToCharArray();
            }

            read.Close();
        }

        private void MainMenuPrint()
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
