using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;

namespace AlphaTank.Program.Logic
{
    public class Collision : ICollision
    {
        public bool DetectCollision(IMap map, int X, int Y)
        {
            if (map == null)
            {
                throw new NoMapException();
            }

            if (map[X, Y] is INonObstacle)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsObstacleOrAlly(IMap map, int X, int Y)
        {
            if (map == null)
            {
                throw new NoMapException();
            }

            if (map[X, Y] is IObstacle)
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

