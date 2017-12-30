using AlphaTank.Program.Models.GameObjects;
using System;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IGameObject
    {
        int RowPosition { get; }
        int ColumnPosition { get; }
        char Representative { get; }
        ConsoleColor Color { get; }
    }
}
