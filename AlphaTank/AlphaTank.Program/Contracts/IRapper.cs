using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Contracts
{
    public interface IRapper
    {
        /*His palms are sweaty, knees weak, arms are heavy
          There's vomit on his sweater already, mom's spaghetti*/
        void Write(string str);
        void WriteLine(string str);

        void SetCursorPosition(int a, int b);

        ConsoleColor ForegroundColor { set; }
    }
}
