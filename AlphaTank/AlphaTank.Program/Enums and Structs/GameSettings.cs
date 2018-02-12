using System;

namespace AlphaTank.Program.Enums_and_Structs
{
    public class GameSettings : IGameSettings
    {
        public GameSettings(int rowsSize, int colsSize, TimeSpan refreshRate, TimeSpan shellCooldown, TimeSpan shellSpeed, TimeSpan enemyTankShootCooldown)
        {
            if (rowsSize <= 0 || colsSize <= 0)
            {
                throw new ArgumentException();
            }

            this.RowsSize = rowsSize;
            this.ColsSize = colsSize;
            this.RefreshRate = refreshRate;
            this.ShellCooldown = shellCooldown;
            this.ShellSpeed = shellSpeed;
            this.EnemyTankShootCooldown = enemyTankShootCooldown;
        }

        public int RowsSize { get; }

        public int ColsSize { get; }

        public TimeSpan RefreshRate { get; }

        public TimeSpan ShellSpeed { get; }

        public TimeSpan ShellCooldown { get; }

        public TimeSpan EnemyTankShootCooldown { get; }

        public bool IsPlayerAlive { get; set; } = true;
    }
}
