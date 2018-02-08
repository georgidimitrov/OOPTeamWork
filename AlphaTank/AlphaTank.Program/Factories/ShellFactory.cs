using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Factories
{
    class ShellFactory
    {
        public IShell CreateShell(int row, int col, IMap map, Direction direction)
        {
            return new Shell(row, col, map, direction);
        }
    }
}
