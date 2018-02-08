using AlphaTank.Program.Contracts;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.GameDisplay
{
    public class Display : IDisplay
    {
        private readonly IRapper rapper;

        //Ctors
        public Display(IRapper rapper)
        {
            this.rapper = rapper;
        }

        //Methods
        public void Resize(int rowsSize, int colSize)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(colSize, rowsSize);
            Console.SetBufferSize(colSize, rowsSize);
        }

        public void Print(IMap map)
        {
            rapper.SetCursorPosition(0, 0);
            for (int row = 0; row < map.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    rapper.ForegroundColor = map[row, col].Color;
                    rapper.Write(map[row, col].Representative.ToString());
                }
            }
        }

        public void Update(IMap map, int oldX, int oldY, int newX, int newY)
        {
            rapper.SetCursorPosition(oldY, oldX);
            rapper.ForegroundColor = map[oldX, oldY].Color;
            rapper.Write(map[oldX, oldY].Representative.ToString());

            rapper.SetCursorPosition(newY, newX);
            rapper.ForegroundColor = map[newX, newY].Color;
            rapper.Write(map[newX, newY].Representative.ToString());
        }
    }
}
