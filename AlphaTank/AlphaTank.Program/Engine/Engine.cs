﻿using AlphaTank.Program.Display;
using AlphaTank.Program.Display.Contracts;
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
                    for (int shell = enemies.Count - 1; shell >= 0; shell--)
                    {
                        var info = enemies[shell].Move();
                        Display.Display.Instance.Update(map, enemies[shell], info);

                        if (info.IsCollided)
                        {
                            enemies.Remove(enemies[shell]);
                        }
                    }

                    if (!Keyboard.IsKeyUp(Key.Space ) && ShellTimePassed())
                    {
                        var shell = playerTank.Shoot();
                        if (shell != null)
                        {
                            enemies.Add(shell);
                            Display.Display.Instance.Update(map, shell, new CollisionInfo(false));
                        }
                    }
                    else if (!Keyboard.IsKeyUp(Key.Up))
                    {
                        var info = playerTank.MoveUp();
                        Display.Display.Instance.Update(map, playerTank, info);
                    }
                    else if (!Keyboard.IsKeyUp(Key.Down))
                    {
                        var info = playerTank.MoveDown();
                        Display.Display.Instance.Update(map, playerTank, info);
                    }
                    else if (!Keyboard.IsKeyUp(Key.Left))
                    {
                        var info = playerTank.MoveLeft();
                        Display.Display.Instance.Update(map, playerTank, info);
                    }
                    else if (!Keyboard.IsKeyUp(Key.Right))
                    {
                        var info = playerTank.MoveRight();
                        Display.Display.Instance.Update(map, playerTank, info);
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
