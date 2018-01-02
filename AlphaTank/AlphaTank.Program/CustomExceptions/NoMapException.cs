using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.CustomExceptions
{
    class NoMapException : Exception
    {
        public NoMapException()
        {
        }

        public NoMapException(string message) : base(message)
        {
        }
    }
}
