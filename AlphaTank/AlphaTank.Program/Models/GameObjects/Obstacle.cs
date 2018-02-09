using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    class Obstacle : GameObject, IObstacle
    {
        public Obstacle(int row, int col) : base(row, col)
        {
            this.Representative = '#';
            this.Color = ConsoleColor.DarkGreen;
        }
    }
}
