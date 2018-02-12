using System.Windows.Input;

namespace AlphaTank.Program.GameEngine.ControlProvider
{
    public class KeyboardWraper : IKeyboardWraper
    {
        public bool IsKeyUp(Key key)
        {
            return Keyboard.IsKeyUp(key);
        }
    }
}
