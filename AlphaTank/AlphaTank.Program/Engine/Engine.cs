using AlphaTank.Program.Display;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;

namespace AlphaTank.Program.Engine
{
    public class Engine
    {
        private GameSettings gameSettings;
        private readonly List<Shell> shells = new List<Shell>();
        private readonly List<EnemyTank> enemyTanks = new List<EnemyTank>();
        private static Engine instance;
        private DateTime timer;
        private DateTime shellTimer;
        private static int shots = 0;


        private int objOldX;
        private int objOldY;

        private int objNewX;
        private int objNewY;

        private bool isPlayerAlive = true;

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
            gameSettings = new GameSettings(21, 30, new TimeSpan(0, 0, 0, 0, 200), new TimeSpan(0, 0, 0, 0, 600));

            Display.Display.Instance.Resize(gameSettings.RowsSize, gameSettings.ColsSize);

            timer = DateTime.Now;
            Map map = new Map("../../Display/Levels/Level1.txt");
            PlayerTank playerTank = new PlayerTank(18, 14, map);
            EnemyTank enemy1 = new EnemyTank(1, 1, map, playerTank);
            enemyTanks.Add(enemy1);
            playerTank.Shots += new EventHandler(ShotCount);
            playerTank.OnShots();
            //Enemy

            if (!MainMenu.Instance.Run())
            {
                return;
            }

            Display.Display.Instance.Print(map);

            //After Start
            while (isPlayerAlive)
            {
                if (GameTimePassed())
                {
                    for (int shell = shells.Count - 1; shell >= 0; shell--)
                    {
                        objOldX = shells[shell].RowPosition;
                        objOldY = shells[shell].ColumnPosition;
                            ICollisionInfo info = shells[shell].Move();

                            if (info.Type == GameObjectType.PlayerTank)
                            {
                                isPlayerAlive = false;
                            }

                            objNewX = shells[shell].RowPosition;
                            objNewY = shells[shell].ColumnPosition;

                            Display.Display.Instance.Update(map, objOldX, objOldY, objNewX, objNewY/*, enemies[shell].Representative*/);

                            if (info.CollisionStatus)
                            {
                                shells.Remove(shells[shell]);
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

                            shells.Add(shell);
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

                    for (int tank = 0; tank < enemyTanks.Count; tank++)
                    {
                        if (enemyTanks[tank].IsEnemyInMap())
                        {
                            objOldX = enemyTanks[tank].RowPosition;
                            objOldY = enemyTanks[tank].ColumnPosition;
                            Shell shell = enemyTanks[tank].DetectPlayer();
                            if (shell != null)
                            {
                                shells.Add(shell);
                                continue;
                            }
                            else if (enemyTanks[tank].Move())
                            {
                                objNewX = enemyTanks[tank].RowPosition;
                                objNewY = enemyTanks[tank].ColumnPosition;

                                Display.Display.Instance.Update(map, objOldX, objOldY, objNewX, objNewY);
                            }
                        }
                        else
                        {

                            Display.Display.Instance.Update(map, objOldX, objOldY, objNewX, objNewY);
                        }
                    }
                    if (map.GetMap[playerTank.RowPosition, playerTank.ColumnPosition] is Road) isPlayerAlive = false;
                }
            }

            MainMenu.Instance.GameOver(/*shots*/);

        }
        private static void ShotCount(object sender, EventArgs args)
        {
            shots++;
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
