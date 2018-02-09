using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    public class PlayerTank : Tank, IPlayerTank
    {
        public PlayerTank(int row, int col, IMap map, IEnvironmentFactory environmentFactory, ICollision collision) : base(row, col, map, environmentFactory, collision)
        {
            this.Color = ConsoleColor.Yellow;
        }

        public event EventHandler Shots;

        public void OnShots()
        {
            this.Shots?.Invoke(this, null);
        }
    }
}
