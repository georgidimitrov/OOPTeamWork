using AlphaTank.Program.Models.GameObjects;

namespace AlphaTank.Program.Models.Contracts
{
    interface IEnemy
    {
        void DetectPlayer(PlayerTank playerTank);
        void Move();
    }
}
