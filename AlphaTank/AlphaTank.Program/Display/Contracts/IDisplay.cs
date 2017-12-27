namespace AlphaTank.Program.Display.Contracts
{
    interface IDisplay
    {
        int Height { get; }
        int Width { get; }

        char[][] Display { get; }
    }
}
