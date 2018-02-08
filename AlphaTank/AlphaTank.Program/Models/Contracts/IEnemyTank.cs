using AlphaTank.Program.Models.GameObjects;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IEnemyTank : IMovableGameObject
    {
        bool Move();

        IShell DetectPlayer();
    }
}
