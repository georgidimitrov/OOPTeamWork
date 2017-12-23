namespace AlphaTank.DisplayControl.Contracts
{
    public interface IDisplay
    {
        int Height { get; }
        int Width { get; }

        char[][] Display { get; }

    }
}
