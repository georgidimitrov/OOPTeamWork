using AlphaTank.Program.Enums_and_Structs;
using System;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IGameObject
    {
        Map Map { get; }

        int RowPosition { get; }

        int ColumnPosition { get; }

        char Representative { get; }

        GameObjectType Type { get; }

        ConsoleColor Color { get; }

        void Destroy();
    }
}
