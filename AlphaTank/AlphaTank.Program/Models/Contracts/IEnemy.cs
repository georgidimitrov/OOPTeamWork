using AlphaTank.Program.Models.GameObjects;

namespace AlphaTank.Program.Models.Contracts
{
    interface IEnemy
    {
        Shell DetectPlayer();
    }
}
