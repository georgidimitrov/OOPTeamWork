using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;

namespace AlphaTank.Program.Models
{
    public class Map
    {
        private readonly IGameObject[,] map = new IGameObject[21, 31];

        public Map(string directory)
        {
            ParseMap(directory);
        }

        public IGameObject[,] GetMap => this.map;

        public void PrintMap()
        {
            if (map == null)
            {
                throw new ArgumentException("There is no map instance.");
            }
            for (int row = 0; row < map.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < map.GetLength(1) - 1; col++)
                {
                    if (this.map[row, col] is PlayerTank)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(map[row, col].Representative);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (this.map[row, col] is Shell)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(map[row, col].Representative);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(map[row, col].Representative);
                    }

                }
            }
        }

        private void ParseMap(string directory)
        {
            string[] lines;
            try
            {
                lines = System.IO.File.ReadAllLines(directory);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid Level directory.");
            }
            for (int i = 0; i < map.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < map.GetLength(1) - 1; j++)
                {
                    switch (lines[i][j])
                    {
                        case '#':
                            map[i, j] = new Obstacle(i, j);
                            break;
                        default:
                            map[i, j] = new Road(i, j);
                            break;
                    }
                }
            }
        }
    }
}
