using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    class Obstacle : GameObject, IObstacle, IIndestructable
    {
        public Obstacle(int row, int col, IMap map) : base(row, col, map)
        {
            this.Representative = '#';
            this.Color = ConsoleColor.DarkGreen;
        }
    }
}
