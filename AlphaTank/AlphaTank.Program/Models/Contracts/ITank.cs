using AlphaTank.Program.Models.GameObjects;

namespace AlphaTank.Program.Models.Contracts
{
    public interface ITank : IMovableGameObject
    {
        Shell Shoot();
    }
}
