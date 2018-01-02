using AlphaTank.Program.Enums_and_Structs;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    class Obstacle : GameObject
    {
        public Obstacle(int row, int col) : base(row, col)
        {
            this.Type = GameObjectType.Obstacle;
            this.Representative = '#';
            this.Color = ConsoleColor.DarkGreen;
        }
    }
}
