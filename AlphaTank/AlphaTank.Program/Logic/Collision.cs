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
            if (map[X, Y] is Road)
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
            if (map[X, Y] is Obstacle || map[X, Y] is EnemyTank)
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

