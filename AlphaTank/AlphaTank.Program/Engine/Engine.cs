using AlphaTank.Program.Display;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace AlphaTank.Program.Engine
{
    public class Engine
    {
        private GameSettings gameSettings;
        private readonly List<Shell> enemies = new List<Shell>();
        private static Engine instance;
        private DateTime timer;
        private DateTime shellTimer;

        private int objOldX;
        private int objOldY;

        private int objNewX;
        private int objNewY;

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
            gameSettings = new GameSettings(21, 30, new TimeSpan(0, 0, 0, 0, 150), new TimeSpan(0, 0, 0, 0, 600));

            Display.Display.Instance.Resize(gameSettings.RowsSize, gameSettings.ColsSize);

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
                        objOldX = enemies[shell].RowPosition;
                        objOldY = enemies[shell].ColumnPosition;

                        ICollisionInfo info = enemies[shell].Move();

                        objNewX = enemies[shell].RowPosition;
                        objNewY = enemies[shell].ColumnPosition;

                        Display.Display.Instance.Update(map, objOldX, objOldY, objNewX, objNewY/*, enemies[shell].Representative*/);

                        if (info.CollisionStatus)
                        {
                            enemies.Remove(enemies[shell]);
                        }
                    }
                    //Shell Move Update

                    objOldX = playerTank.RowPosition;
                    objOldY = playerTank.ColumnPosition;
                    if (!Keyboard.IsKeyUp(Key.Space) && ShellTimePassed())
                    {
                        var shell = playerTank.Shoot();
                        if (shell.Map != null)
                        {
                            objNewX = shell.RowPosition;
                            objNewY = shell.ColumnPosition;

                            Display.Display.Instance.Update(map, objOldX, objOldY, objNewX, objNewY/*, shell.Representative*/);

                            enemies.Add(shell);
                        }
                    }
                    //Shell Shoot Update

                    else if (!Keyboard.IsKeyUp(Key.Up))
                    {
                        var info = playerTank.MoveUp();

                        objNewX = playerTank.RowPosition;
                        objNewY = playerTank.ColumnPosition;

                        Display.Display.Instance.Update(map, objOldX, objOldY, objNewX, objNewY/*, playerTank.Representative*/);
                    }
                    else if (!Keyboard.IsKeyUp(Key.Down))
                    {
                        var info = playerTank.MoveDown();

                        objNewX = playerTank.RowPosition;
                        objNewY = playerTank.ColumnPosition;

                        Display.Display.Instance.Update(map, objOldX, objOldY, objNewX, objNewY/*, playerTank.Representative*/);
                    }
                    else if (!Keyboard.IsKeyUp(Key.Left))
                    {
                        var info = playerTank.MoveLeft();

                        objNewX = playerTank.RowPosition;
                        objNewY = playerTank.ColumnPosition;

                        Display.Display.Instance.Update(map, objOldX, objOldY, objNewX, objNewY/*, playerTank.Representative*/);
                    }
                    else if (!Keyboard.IsKeyUp(Key.Right))
                    {
                        var info = playerTank.MoveRight();

                        objNewX = playerTank.RowPosition;
                        objNewY = playerTank.ColumnPosition;

                        Display.Display.Instance.Update(map, objOldX, objOldY, objNewX, objNewY/*, playerTank.Representative*/);
                    }
                    //Player Tank Update
                }
            }
        }

        private bool GameTimePassed()
        {
            TimeSpan timespan = DateTime.Now - timer;
            if (timespan > gameSettings.RefreshRate)
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
            TimeSpan timespan = DateTime.Now - shellTimer;
            if (timespan > gameSettings.ShellCooldown)
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
