using AlphaTank.Program.Enums_and_Structs;
using System;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IGameObject
    {
        IMap Map { get; }

        int RowPosition { get; }

        int ColumnPosition { get; }

        char Representative { get; }

        ConsoleColor Color { get; }

        void Destroy();
    }
}
