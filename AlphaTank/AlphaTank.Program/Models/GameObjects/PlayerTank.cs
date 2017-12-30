﻿using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects.Common;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    public class PlayerTank : Tank
    {
        public PlayerTank(int row, int col, Map map) : base(row, col, map)
        {
            this.Type = GameObjectType.PlayerTank;
            this.Color = ConsoleColor.Yellow;
        }
    }
}
