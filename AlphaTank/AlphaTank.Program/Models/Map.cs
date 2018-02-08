using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;

namespace AlphaTank.Program.Models
{
    public class Map : IMap
    {
        private readonly IGameObject[,] map = new IGameObject[21, 30];

        public Map(string directory)
        {
            ParseMap(directory);
        }

        public IGameObject this[int row, int col] { get { return this.map[row, col]; } set { this.map[row, col] = value; } }

        public int GetLength(int dimention)
        {
            return map.GetLength(dimention);
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
                for (int j = 0; j < map.GetLength(1); j++)
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
