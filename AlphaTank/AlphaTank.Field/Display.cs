using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlphaTank.Field
{
    public class Display
    {
        //Fields
        private int height = 20;
        private int displayWidth = 49;
        private int mapWidth = 30;
        private char[][] display;
        private static readonly Display SingleInstance = new Display();


        //Ctors
        private Display()
        {
            this.Height = this.height;
            this.DisplayWidth = this.displayWidth;
            this.MapWidth = this.mapWidth;
            this.display = new char[this.Height][];
            for (int row = 0; row < Height; row++)
            {
                display[row] = new char[DisplayWidth];
            }
        }


        //Props
        public int Height { get; }
        public int DisplayWidth { get; }
        public int MapWidth { get; }

        public static Display Instance
        {
            get
            {
                return SingleInstance;
            }
        }


        //Methods
        public void RenderDisplay()
        {
            StreamReader read = new StreamReader(@"C:\Users\Dimitar Petrow\source\repos\TATeamWork\AlphaTank\AlphaTank.Field\Levels\Level1.txt");
            for (int row = 0; row < Height; row++)
            {
                string line = read.ReadLine();
                for (int col = 0; col < MapWidth; col++)
                {
                    display[row][col] = line[col];
                }
            }
            read.Close();

            read = new StreamReader(@"C:\Users\Dimitar Petrow\source\repos\TATeamWork\AlphaTank\AlphaTank.Field\Levels\SideBar\Info.txt");
            for (int row = 0; row < Height; row++)
            {
                string line = read.ReadLine();
                for (int col = MapWidth; col < DisplayWidth; col++)
                {
                    display[row][col] = line[col - MapWidth];
                }
            }
            read.Close();


        }

        public void PrintDisplay()
        {
            for (int r = 0; r < Height; r++)
            {
                for (int c = 0; c < DisplayWidth; c++)
                {
                    Console.Write(display[r][c]);
                }
            }
        }

    }
}
