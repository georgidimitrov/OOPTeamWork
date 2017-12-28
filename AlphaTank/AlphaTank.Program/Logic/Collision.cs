using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Logic
{
    public static class Collision
    {
        public static bool DetectCollision(Map map,int X, int Y)
        {
            if (map.GetMap[X,Y] is Road)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

