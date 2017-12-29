using AlphaTank.Program.Models;
using AlphaTank.Program.Models.GameObjects;

namespace AlphaTank.Program.Logic
{
    public static class Collision
    {
        public static bool DetectCollision(Map map, int X, int Y)
        {
            if (map.Get[X, Y] is Road)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

