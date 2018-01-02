using AlphaTank.Program.Enums_and_Structs;
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

        public event EventHandler Shots;
        public void OnShots()
        {
            this.Shots?.Invoke(this, null);
        }
    }
}
