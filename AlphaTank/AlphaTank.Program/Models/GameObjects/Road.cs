﻿using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    public class Road : GameObject, INonObstacle
    {
        public Road(int row, int col, IMap map) : base(row, col, map)
        {
            this.Representative = ' ';
            this.Color = ConsoleColor.Black;
        }
    }
}
