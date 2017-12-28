using AlphaTank.Program.Models;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;

namespace AlphaTank.Program.Display.Contracts
{
    interface IMap
    {
        int MapHeight { get; }
        int MapWidth { get; }

        Map Map { get; }

        PlayerTank MyTank { get; }
    }
}
