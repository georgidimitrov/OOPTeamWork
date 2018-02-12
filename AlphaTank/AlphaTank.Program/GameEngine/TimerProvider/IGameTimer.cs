namespace AlphaTank.Program.GameEngine.TimerProvider
{
    public interface IGameTimer
    {
        void RunTimers();

        bool ShellSpeed();

        bool GameTimePassed();

        bool ShellCooldownPassed();

        bool EnemyTankShootCooldown();
    }
}
