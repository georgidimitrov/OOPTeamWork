using System;

namespace AlphaTank.Program.Enums_and_Structs
{
    public struct GameSettings
    {
        public GameSettings(int rowsSize, int colsSize, TimeSpan refreshRate, TimeSpan shellCooldown)
        {
            this.RowsSize = rowsSize;
            this.ColsSize = colsSize;
            this.RefreshRate = refreshRate;
            this.ShellCooldown = shellCooldown;
        }

        public int RowsSize { get; }

        public int ColsSize { get; }

        public TimeSpan RefreshRate { get; }

        public TimeSpan ShellCooldown { get; }
    }
}
