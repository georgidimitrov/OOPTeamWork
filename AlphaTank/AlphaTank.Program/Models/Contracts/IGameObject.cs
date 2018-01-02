using AlphaTank.Program.Enums_and_Structs;
using System;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IGameObject
    {
        int RowPosition { get; }
        int ColumnPosition { get; }
        char Representative { get; }
        GameObjectType Type { get; }
        ConsoleColor Color { get; }
    }
}
