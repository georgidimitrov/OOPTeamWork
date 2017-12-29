using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;

namespace AlphaTank.Program.Models
{
    public class Map
    {
        private readonly IGameObject[,] map = new IGameObject[21, 31];
        private readonly IMovableGameObject[,] mapMov = new IMovableGameObject[21, 31];

        public Map(string directory)
        {
            ParseMap(directory);
        }

        public IGameObject[,] Get => this.map;
        public IMovableGameObject[,] GetMov => this.mapMov;

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
                    Console.Write(map[row, col].Representative);

                }
                Console.WriteLine();
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
                        case ' ':
                            map[i, j] = new Road(i, j);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
