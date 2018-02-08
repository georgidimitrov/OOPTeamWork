using AlphaTank.Program.Models.GameObjects;

namespace AlphaTank.Program.Models.Contracts
{
    public interface ITank
    {
        IShell Shoot();
    }
}
