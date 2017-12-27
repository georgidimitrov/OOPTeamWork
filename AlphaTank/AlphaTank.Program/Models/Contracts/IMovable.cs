namespace AlphaTank.Program.Models.Contracts
{
    public interface IMovable
    {
        void MoveUp(IGameObject[][] map, char[][] display);
        void MoveDown(IGameObject[][] map, char[][] display);
        void MoveLeft(IGameObject[][] map, char[][] display);
        void MoveRight(IGameObject[][] map, char[][] display);
    }
}
