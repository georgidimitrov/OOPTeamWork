using System;
using System.IO;
using System.Threading;
using System.Windows.Input;

namespace AlphaTank.Program.Display
{
    public class MainMenu
    {
        //Fields
        private static readonly MainMenu instance = new MainMenu();

        private int menu = 1;

        //Ctors
        private MainMenu()
        {
            this.Display = new char[Console.BufferHeight][];

            this.GetDisplayDesign();

            if (Console.BufferHeight != Display.Length || Console.BufferWidth != Display[0].Length)
            {
                throw new ArgumentException("Console Sizes must be (21; 30)!");
            }

        }

        //Props
        public static MainMenu Instance { get { return instance; } }

        public char[][] Display { get; private set; }

        //Methods
        public bool Run()
        {
            MainMenuPrint();
            return WaitingForPlayer();
        }

        private bool WaitingForPlayer()
        {
            DateTime dt = DateTime.Now;

            CursorMenu(1);

            int shellRow = 10;
            int shellCol = 18;

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
                            //AlphaTank.Program.Display.Display.Instance.Run();
                            //MainMenuPrint();
                            //CursorMenu(1);
                            Console.Clear();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    Console.SetCursorPosition(shellCol, shellRow);
                    Console.Write(' ');
                    shellCol++;
                    if (shellCol == 28)
                    {
                        shellCol = 18;
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
                    Console.SetCursorPosition(17, 16);
                    Console.Write(' ');
                    Console.SetCursorPosition(17 + 5, 16);
                    Console.Write(' ');

                    Console.SetCursorPosition(17, 13);
                    Console.Write('>');
                    Console.SetCursorPosition(17 + 6, 13);
                    Console.Write('<');
                    break;
                case 2:
                    Console.SetCursorPosition(17, 13);
                    Console.Write(' ');
                    Console.SetCursorPosition(17 + 6, 13);
                    Console.Write(' ');

                    Console.SetCursorPosition(17, 16);
                    Console.Write('>');
                    Console.SetCursorPosition(17 + 5, 16);
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
                    Console.SetCursorPosition(17, 16);
                    Console.Write(' ');
                    Console.SetCursorPosition(17 + 5, 16);
                    Console.Write(' ');

                    Console.SetCursorPosition(17, 13);
                    Console.Write('>');
                    Console.SetCursorPosition(17 + 6, 13);
                    Console.Write('<');

                    menu = 1;

                    break;
                case 'd':
                    Console.SetCursorPosition(17, 13);
                    Console.Write(' ');
                    Console.SetCursorPosition(17 + 6, 13);
                    Console.Write(' ');


                    Console.SetCursorPosition(17, 16);
                    Console.Write('>');
                    Console.SetCursorPosition(17 + 5, 16);
                    Console.Write('<');

                    menu = 2;

                    break;

                default:
                    break;
            }
        }

        private void GetDisplayDesign()
        {
            StreamReader read = new StreamReader("../../Display/MainMenu/MainMenu.txt");

            for (int row = 0; row < Console.BufferHeight - 1; row++)
            {
                Display[row] = read.ReadLine().ToCharArray();
            }

            read.Close();
        }

        private void MainMenuPrint()
        {
            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < Console.BufferHeight - 1; row++)
            {
                for (int col = 0; col < Console.BufferWidth; col++)
                {
                    Console.Write(Display[row][col]);
                }
            }
        }

        public void Victory()
        {
            StreamReader read = new StreamReader("../../Display/EndScreen/Victory.txt");

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;

            for (int row = 0; row < Console.BufferHeight - 1; row++)
            {
                Console.Write(read.ReadLine());
            }

            read.Close();

            Thread.Sleep(10000);
        }

        public void GameOver()
        {
            StreamReader read = new StreamReader("../../Display/GameOver/GameOver.txt");

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;

            for (int row = 0; row < Console.BufferHeight - 1; row++)
            {
                Console.Write(read.ReadLine());
            }

            read.Close();

            Thread.Sleep(10000);
        }
    }
}
