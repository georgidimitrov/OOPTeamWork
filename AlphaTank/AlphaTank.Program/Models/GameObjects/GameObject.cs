using AlphaTank.Program.Models.Contracts;
using System;
using AlphaTank.Program.Models.GameObjects.Common;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class GameObject : IGameObject
    {
        public GameObject(int row, int col)
        {
            if (row < 0 || row >= Console.BufferHeight)
            {
                throw new ArgumentException("Row must be between [0; 20)!");
            }
            if (col < 0 || col >= Console.BufferWidth)
            {
                throw new ArgumentException("Column must be between [0; 50)!");
            }

            this.RowPosition = row;
            this.ColumnPosition = col;
        }

        public GameObjectType Type { get; protected set; }

        public int RowPosition { get; protected set; }

        public int ColumnPosition { get; protected set; }

        public virtual char Representative { get; protected set; }

        public ConsoleColor Color { get; protected set; }
    }
}
