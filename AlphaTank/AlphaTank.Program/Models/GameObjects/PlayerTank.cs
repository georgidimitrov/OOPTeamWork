using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.Models.GameObjects
{
    public class PlayerTank : Tank
    {
        public PlayerTank(int row, int col) : base(row, col)
        {
            this.Representative = '@';
        }

        public override void MoveUp(IGameObject[][] map, char[][] display)
        {
            //if Collision Detection?

            map[this.RowPosition][this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            map[this.RowPosition - 1][this.ColumnPosition] = new PlayerTank(this.RowPosition - 1, this.ColumnPosition);

            display[this.RowPosition + 1][this.ColumnPosition + 1] = map[this.RowPosition][this.ColumnPosition].Representative;
            display[this.RowPosition + 1 - 1][this.ColumnPosition + 1] = map[this.RowPosition - 1][this.ColumnPosition].Representative;

            Console.SetCursorPosition(this.ColumnPosition + 1, this.RowPosition + 1);
            Console.Write(display[this.RowPosition + 1][this.ColumnPosition + 1]);

            Console.SetCursorPosition(this.ColumnPosition + 1, this.RowPosition + 1 - 1);
            Console.Write(display[this.RowPosition + 1 - 1][this.ColumnPosition + 1]);

            this.RowPosition--;
        }
        public override void MoveRight(IGameObject[][] map, char[][] display)
        {
            //if Collision Detection?

            map[this.RowPosition][this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            map[this.RowPosition][this.ColumnPosition + 1] = new PlayerTank(this.RowPosition, this.ColumnPosition + 1);

            display[this.RowPosition + 1][this.ColumnPosition + 1] = map[this.RowPosition][this.ColumnPosition].Representative;
            display[this.RowPosition + 1][this.ColumnPosition + 1 + 1] = map[this.RowPosition][this.ColumnPosition + 1].Representative;

            Console.SetCursorPosition(this.ColumnPosition + 1, this.RowPosition + 1);
            Console.Write(display[this.RowPosition + 1][this.ColumnPosition + 1]);

            Console.SetCursorPosition(this.ColumnPosition + 1 + 1, this.RowPosition + 1);
            Console.Write(display[this.RowPosition + 1][this.ColumnPosition + 1 + 1]);

            this.ColumnPosition++;
        }
        public override void MoveDown(IGameObject[][] map, char[][] display)
        {
            //if Collision Detection?

            map[this.RowPosition][this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            map[this.RowPosition + 1][this.ColumnPosition] = new PlayerTank(this.RowPosition + 1, this.ColumnPosition);

            display[this.RowPosition + 1][this.ColumnPosition + 1] = map[this.RowPosition][this.ColumnPosition].Representative;
            display[this.RowPosition + 1 + 1][this.ColumnPosition + 1] = map[this.RowPosition + 1][this.ColumnPosition].Representative;

            Console.SetCursorPosition(this.ColumnPosition + 1, this.RowPosition + 1);
            Console.Write(display[this.RowPosition + 1][this.ColumnPosition + 1]);

            Console.SetCursorPosition(this.ColumnPosition + 1, this.RowPosition + 1 + 1);
            Console.Write(display[this.RowPosition + 1 + 1][this.ColumnPosition + 1]);

            this.RowPosition++;
        }
        public override void MoveLeft(IGameObject[][] map, char[][] display)
        {
            //if Collision Detection?

            map[this.RowPosition][this.ColumnPosition] = new Road(this.RowPosition, this.ColumnPosition);
            map[this.RowPosition][this.ColumnPosition - 1] = new PlayerTank(this.RowPosition, this.ColumnPosition - 1);

            display[this.RowPosition + 1][this.ColumnPosition + 1] = map[this.RowPosition][this.ColumnPosition].Representative;
            display[this.RowPosition + 1][this.ColumnPosition + 1 - 1] = map[this.RowPosition][this.ColumnPosition - 1].Representative;

            Console.SetCursorPosition(this.ColumnPosition + 1, this.RowPosition + 1);
            Console.Write(display[this.RowPosition + 1][this.ColumnPosition + 1]);

            Console.SetCursorPosition(this.ColumnPosition + 1 - 1, this.RowPosition + 1);
            Console.Write(display[this.RowPosition + 1][this.ColumnPosition + 1 - 1]);

            this.ColumnPosition--;
        }


        public override void Shoot()
        {

        }
    }
}
