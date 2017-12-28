using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program
{
    class Map
    {
        private readonly GameObject[,] map = new GameObject[21,31];
        public Map(string directory)
        {
            ParseMap(@"C:\Users\Gosho\source\TeamWorkProject\OOPTeamWork\AlphaTank\AlphaTank.DisplayControl\Levels\Level1.txt");
        }

        public void PrintMap()
        {
            if(map == null)
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
                            map[i,j] = new Obstacle(i, j);
                            break;
                        case ' ':
                            map[i,j] = new Road(i, j);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
