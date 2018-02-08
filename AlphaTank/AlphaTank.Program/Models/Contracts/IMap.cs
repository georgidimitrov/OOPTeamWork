using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IMap
    {
        IGameObject this[int row, int col] { get; set; }

        int GetLength(int dimention);
    }
}
