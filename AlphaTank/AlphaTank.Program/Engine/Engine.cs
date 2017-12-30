using AlphaTank.Program.Display;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace AlphaTank.Program.Engine
{
    public class Engine
    {
        private readonly List<Shell> enemies = new List<Shell>();
        private readonly List<Shell> toDestroy = new List<Shell>();
        private static Engine instance;
        private DateTime timer;
        private DateTime shellTimer;

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
            Display.Display.Instance.Resize();

            timer = DateTime.Now;
            Map map = new Map("../../Display/Levels/Level1.txt");
            PlayerTank playerTank = new PlayerTank(18, 14, map);
            //Enemy

            if (!MainMenu.Instance.Run())
            {
                return;
            }

            Display.Display.Instance.Print(map);

            //After Start
            while (true)
            {
                if (GameTimePassed())
                {
                    foreach (var shell in enemies)
                    {
                        if (!shell.Move())
                        {
                            toDestroy.Add(shell);
                        }
                    }

                    if (!Keyboard.IsKeyUp(Key.Space) && ShellTimePassed())
                    {
                        enemies.Add(playerTank.Shoot());
                    }
                    else if (!Keyboard.IsKeyUp(Key.Up))
                    {
                        if (playerTank.MoveUp())
                        {
                            //Display.Display.Instance.Update(map, playerTank);
                        }
                    }
                    else if (!Keyboard.IsKeyUp(Key.Down))
                    {
                        if (playerTank.MoveDown())
                        {
                            //Display.Display.Instance.Update(map, playerTank);
                        }
                    }
                    else if (!Keyboard.IsKeyUp(Key.Left))
                    {
                        if (playerTank.MoveLeft())
                        {
                            //Display.Display.Instance.Update(map, playerTank);
                        }
                    }
                    else if (!Keyboard.IsKeyUp(Key.Right))
                    {
                        if (playerTank.MoveRight())
                        {
                            //Display.Display.Instance.Update(map, playerTank);
                        }
                    }

                    foreach (var bb in toDestroy)
                    {
                        enemies.Remove(bb);
                    }
                }
            }

        }

        private bool GameTimePassed()
        {
            TimeSpan check = new TimeSpan(0, 0, 0, 0, 150);
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

        private bool ShellTimePassed()
        {
            TimeSpan check = new TimeSpan(0, 0, 0, 0, 600);
            TimeSpan timespan = DateTime.Now - shellTimer;
            if (timespan > check)
            {
                shellTimer = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
