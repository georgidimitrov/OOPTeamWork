using System;

namespace AlphaTank.Program.Enums_and_Structs
{
    public interface IGameSettings
    {
        int RowsSize { get; }

        int ColsSize { get; }

        TimeSpan RefreshRate { get; }

        TimeSpan ShellSpeed { get; }

        TimeSpan ShellCooldown { get; }

        TimeSpan EnemyTankShootCooldown { get; }

        bool IsPlayerAlive { get; set; }
    }
}
