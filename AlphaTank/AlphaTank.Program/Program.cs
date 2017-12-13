using AlphaTank.Field;
using System;
using System.Threading;
using System.Windows.Input;

namespace AlphaTank.Program
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Display.Instance.RenderDisplay();
            Display.Instance.PrintDisplay();

            
            ////Key Press N Key Hold Handlers
            
            //bool clicked = false;
            //string toggled = Keyboard.GetKeyStates(Key.Up).ToString();
            //while (true)
            //{
            //    Thread.Sleep(100);

            //    if (toggled == "None" && Keyboard.GetKeyStates(Key.Up).ToString() == "Toggled")
            //    {
            //        clicked = true;
            //        toggled = "Toggled";
            //    }
            //    else if (toggled == "Toggled" && Keyboard.GetKeyStates(Key.Up).ToString() == "None")
            //    {
            //        clicked = true;
            //        toggled = "None";
            //    }

            //    if (clicked || Keyboard.IsKeyDown(Key.Up))
            //    {
            //        clicked = false;
            //        Console.WriteLine("presed");
            //    }
            //    else
            //    {
            //        Console.WriteLine("not presed");
            //    }

            //}
        }
    }
}
