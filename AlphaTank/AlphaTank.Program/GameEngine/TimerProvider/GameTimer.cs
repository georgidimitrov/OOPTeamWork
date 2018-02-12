using AlphaTank.Program.Enums_and_Structs;
using System;

namespace AlphaTank.Program.GameEngine.TimerProvider
{
    public class GameTimer : IGameTimer
    {
        private DateTime timerGameRefresh;
        private DateTime timerShell;
        private DateTime shellTimer;
        private DateTime enemyCooldown;

        private readonly IGameSettings gameSettings;

        public GameTimer(IGameSettings gameSettings)
        {
            this.gameSettings = gameSettings ?? throw new ArgumentNullException();
        }

        public void RunTimers()
        {
            this.timerGameRefresh = DateTime.Now;
            this.timerShell = DateTime.Now;
            this.shellTimer = DateTime.Now;
            this.enemyCooldown = DateTime.Now;
        }

        public bool ShellSpeed()
        {
            TimeSpan timespan = DateTime.Now - this.timerShell;

            if (timespan > this.gameSettings.ShellSpeed)
            {
                this.timerShell = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GameTimePassed()
        {
            TimeSpan timespan = DateTime.Now - this.timerGameRefresh;

            if (timespan > this.gameSettings.RefreshRate)
            {
                this.timerGameRefresh = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ShellCooldownPassed()
        {
            TimeSpan timespan = DateTime.Now - this.shellTimer;

            if (timespan > this.gameSettings.ShellCooldown)
            {
                this.shellTimer = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EnemyTankShootCooldown()
        {
            if (this.gameSettings.EnemyTankShootCooldown < DateTime.Now - this.enemyCooldown)
            {
                this.enemyCooldown = DateTime.Now;
                return true;
            }
            return false;
        }

    }
}
