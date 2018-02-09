using AlphaTank.Program.Models.Contracts;
using System;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.CustomExceptions;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class GameObject : IGameObject
    {
        public GameObject(int row, int col, IMap map)
        {
            this.Map = map ?? throw new NoMapException();

            if (row < 0 || row >= this.Map.GetLength(0))
            {
                throw new ArgumentException();
            }
            if (col < 0 || col >= this.Map.GetLength(1))
            {
                throw new ArgumentException();
            }

            this.RowPosition = row;
            this.ColumnPosition = col;
        }

        public IMap Map { get; protected set; }

        public int RowPosition { get; protected set; }

        public int ColumnPosition { get; protected set; }

        public char Representative { get; protected set; }

        public ConsoleColor Color { get; protected set; }


        public void Destroy()
        {
            this.Map = null;
        }
    }
}
