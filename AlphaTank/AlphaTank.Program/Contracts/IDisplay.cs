using AlphaTank.Program.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Contracts
{
    public interface IDisplay
    {
        void Resize(int rowsSize, int colSize);

        void Print(IMap map);

        void Update(IMap map, int oldX, int oldY, int newX, int newY);
    }
}
