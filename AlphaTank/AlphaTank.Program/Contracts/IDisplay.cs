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
        int OldX { get; set; }
        int OldY { get; set; }

        int NewX { get; set; }
        int NewY { get; set; }

        void Resize(int rowsSize, int colSize);

        void Print();

        void Update();
    }
}
