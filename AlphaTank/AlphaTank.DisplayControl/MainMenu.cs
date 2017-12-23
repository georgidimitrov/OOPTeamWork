using System;
using AlphaTank.DisplayControl.Contracts;
using System.IO;
using System.Threading;
using System.Windows.Input;
using System.Diagnostics;

namespace AlphaTank.DisplayControl
{
    public class MainMenu : IDisplay
    {
        //Fields
        private static readonly MainMenu instance = new MainMenu();
        private int menu = 1;

        //Ctors
        private MainMenu()
        {
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

            MoveCursor();

            int shellRow = 10;
            int shellCol = 20;

            while (true)
            {
                TimeSpan elapsed = DateTime.Now - dt;

                if (elapsed.Milliseconds > 1000)
                {

                    if ((!Keyboard.IsKeyUp(Key.Up) || !Keyboard.IsKeyUp(Key.Down)))
                    {
                        MoveCursor();
                    }
                    if (!Keyboard.IsKeyUp(Key.Enter))
                    {
                        if (menu == 1)
                        {
                            return;
                        }
                        else
                        {
                            //game start
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
                else
                {
                    if ((!Keyboard.IsKeyUp(Key.Up) || !Keyboard.IsKeyUp(Key.Down)))
                    {
                        MoveCursor();
                    }
                    if (!Keyboard.IsKeyUp(Key.Enter))
                    {
                        if (menu == 2)
                        {
                            return;
                        }
                        else
                        {
                            //shutdown
                        }
                    }
                }


            }
        }

        private void MoveCursor()
        {
            switch (menu)
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

                    menu = 2;

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

                    menu = 1;

                    break;

                default:
                    break;
            }
        }

        private void GetDisplayDesign()
        {
            StreamReader read = new StreamReader(@"C:\Users\Dimitar Petrow\source\repos\TATeamWork\AlphaTank\AlphaTank.DisplayControl\MainMenu\MainMenu.txt");

            for (int row = 0; row < Height; row++)
            {
                Display[row] = read.ReadLine().ToCharArray();
            }

            read.Close();
        }

        private void MainMenuPrint()
        {
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
