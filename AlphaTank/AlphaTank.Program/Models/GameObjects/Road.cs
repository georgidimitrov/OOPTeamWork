namespace AlphaTank.Program.Models.GameObjects
{
    public class Road : GameObject
    {
        public Road(int row, int col) : base(row, col)
        {
            this.Representative = ' ';
        }
    }
}
