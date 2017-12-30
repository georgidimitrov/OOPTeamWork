using AlphaTank.Program.Models.GameObjects.Common;
using System;

namespace AlphaTank.Program.Models.Contracts
{
    public interface IGameObject
    {
        GameObjectType Type { get; }
        int RowPosition { get; }
        int ColumnPosition { get; }
        char Representative { get; }
        ConsoleColor Color { get; }
    }
}
