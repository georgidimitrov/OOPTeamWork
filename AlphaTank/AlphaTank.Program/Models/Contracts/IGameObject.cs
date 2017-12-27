using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Models.Contracts
{
    interface IGameObject
    {
        int RowPosition { get; }
        int ColumnPosition { get; }

    }
}
