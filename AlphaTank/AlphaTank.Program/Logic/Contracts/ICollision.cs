using AlphaTank.Program.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.Program.Logic.Contracts
{
    public interface ICollision
    {
        bool DetectCollision(IMap map, int X, int Y);
        bool IsObstacleOrAlly(IMap map, int X, int Y);
    }
}
