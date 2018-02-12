using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.GameEngine.TimerProvider;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
namespace AlphaTank.Program.Factories.Contracts
{
    public interface IEnvironmentFactory
    {
        IShell CreateShell(int row, int col, IMap map, Direction direction, IEnvironmentFactory environmentFactory, ICollision collision);
        INonObstacle CreateRoad(int row, int col, IMap map);
        IEnemyTank CreateEnemyTank(int row, int col, Direction direction, IMap map, IPlayerTank playerTank, IEnvironmentFactory factory, ICollision collision, IGameTimer gameTimer);
        IObstacle CreateObstacle(int row, int col, IMap map);
    }
}
