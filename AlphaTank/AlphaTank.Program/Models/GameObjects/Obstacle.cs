namespace AlphaTank.Program.Models.GameObjects
{
    class Obstacle : GameObject
    {
        public Obstacle(int row, int col) : base(row, col)
        {
            this.Representative = '#';
        }
    }
}
