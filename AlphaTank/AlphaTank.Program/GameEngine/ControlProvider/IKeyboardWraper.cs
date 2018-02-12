using System.Windows.Input;

namespace AlphaTank.Program.GameEngine.ControlProvider
{
    public interface IKeyboardWraper
    {
        bool IsKeyUp(Key key);
    }
}
