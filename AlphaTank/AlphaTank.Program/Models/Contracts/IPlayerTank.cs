using System;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IPlayerTank : IMovableGameObject, ITank
    {
        event EventHandler Shots;

        void OnShots();
    }
}
