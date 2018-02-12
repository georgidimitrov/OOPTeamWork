using AlphaTank.Program.Contracts;
using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.Contracts;
using System;

namespace AlphaTank.Program.GameDisplay
{
    public class Display : IDisplay
    {
        private int oldX;
        private int oldY;

        private int newX;
        private int newY;

        private readonly IRapper rapper;
        private readonly IMap map;
        private readonly IGameSettings gameSettings;
        

        //Ctors
        public Display(IRapper rapper, IMap map, IGameSettings gameSettings)
        {
            this.rapper = rapper ?? throw new ArgumentNullException();
            this.map = map ?? throw new NoMapException();
            this.gameSettings = gameSettings ?? throw new ArgumentNullException();
        }

        //Props
        public int OldX
        {
            get
            {
                return this.oldX;
            }
            set
            {
                if (value < 0 || value >= gameSettings.RowsSize - 1)
                {
                    throw new ArgumentException();
                }

                this.oldX = value;
            }
        }

        public int OldY
        {
            get
            {
                return this.oldY;
            }
            set
            {
                if (value < 0 || value >= gameSettings.ColsSize)
                {
                    throw new ArgumentException();
                }

                this.oldY = value;
            }
        }

        public int NewX
        {
            get
            {
                return this.newX;
            }
            set
            {
                if (value < 0 || value >= gameSettings.RowsSize - 1)
                {
                    throw new ArgumentException();
                }

                this.newX = value;
            }
        }

        public int NewY
        {
            get
            {
                return this.newY;
            }
            set
            {

                if (value < 0 || value >= gameSettings.ColsSize)
                {
                    throw new ArgumentException();
                }
                this.newY = value;
            }
        }

        //Methods
        public void Resize(int rowsSize, int colSize)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(colSize, rowsSize);
            Console.SetBufferSize(colSize, rowsSize);
        }

        public void Print()
        {
            this.rapper.SetCursorPosition(0, 0);

            for (int row = 0; row < this.map.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < this.map.GetLength(1); col++)
                {
                    this.rapper.ForegroundColor = map[row, col].Color;
                    this.rapper.Write(map[row, col].Representative.ToString());
                }
            }
        }

        public void Update()
        {
            this.rapper.SetCursorPosition(this.OldY, this.OldX);
            this.rapper.ForegroundColor = this.map[this.OldX, this.OldY].Color;
            this.rapper.Write(this.map[this.OldX, this.OldY].Representative.ToString());

            this.rapper.SetCursorPosition(this.NewY, this.NewX);
            this.rapper.ForegroundColor = this.map[this.NewX, this.NewY].Color;
            this.rapper.Write(this.map[this.NewX, this.NewY].Representative.ToString());
        }
    }
}
