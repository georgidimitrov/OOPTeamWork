using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class Tank : GameObject, ITank
    {
        public Tank(int row, int col) : base(row, col)
        {
        }

        }

        public void Shoot()
        {

        public abstract void MoveUp(IGameObject[][] map, char[][] display);

        public abstract void Shoot();
    }
}
