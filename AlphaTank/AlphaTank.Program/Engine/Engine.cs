using AlphaTank.Program.Models;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlphaTank.Program.Engine
{
    public class Engine
    {
        private readonly List<Shell> enemies = new List<Shell>();
        private static Engine instance;
        private DateTime timer;
        private Engine() { }
        

        public static Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }
                return instance;
            }
        }

        public void Start()
        {
            Console.CursorVisible = false;
            timer = DateTime.Now;
            //Display.Resize()
            Map map = new Map("../../Display/Levels/Level1.txt");
            PlayerTank playerTank = new PlayerTank(18, 14, map);
            //Enemy
            //Display Main menu
            //After Start
            while (true)
            {
                if (TimePassed())
                {
                    foreach (var shell in enemies)
                    {
                        shell.Move();
                    }
                    if (!Keyboard.IsKeyUp(Key.Space))
                    {
                                enemies.Add(playerTank.Shoot());
                    }
                    else if (!Keyboard.IsKeyUp(Key.Up))
                    {
                        playerTank.MoveUp();

                    }
                    else if (!Keyboard.IsKeyUp(Key.Down))
                    {
                        playerTank.MoveDown();
                    }
                    else if (!Keyboard.IsKeyUp(Key.Left))
                    {
                        playerTank.MoveLeft();
                    }
                    else if (!Keyboard.IsKeyUp(Key.Right))
                    {
                        if (playerTank.MoveRight())
                        {
                        }
                    }
                    Console.SetCursorPosition(0, 0);
                    map.PrintMap();
                }
            }

        }
        private bool TimePassed()
        {
            TimeSpan check = new TimeSpan(0, 0, 0, 0, 450);
            TimeSpan timespan = DateTime.Now - timer;
            if (timespan > check)
            {
                timer = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
