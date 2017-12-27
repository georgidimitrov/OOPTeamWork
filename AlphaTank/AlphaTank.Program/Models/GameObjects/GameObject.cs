using AlphaTank.Program.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Models.GameObjects
{
    public abstract class GameObject : IGameObject
    {
        private int rowPosition;
        private int colPosition;

        public GameObject(int row, int col)
        {
        }
        
        public int RowPosition => throw new NotImplementedException();

        public int ColumnPosition => throw new NotImplementedException();

        public virtual void MoveDown()
        {
        }

        public virtual void MoveLeft()
        {
        }

        public virtual void MoveRight()
        {
        }

        public virtual void MoveUp()
        {
        }
    }
}
