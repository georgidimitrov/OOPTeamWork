using AlphaTank.Program.GameDisplay;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using AlphaTank.Program.Contracts;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;

namespace AlphaTank.Program.GameEngine
{
    public class Engine
    {
        private GameSettings gameSettings;
        private readonly List<IShell> shells = new List<IShell>();
        private readonly List<IEnemyTank> enemyTanks = new List<IEnemyTank>();
        private DateTime timerGameRefresh;
        private DateTime timerShell;
        private DateTime shellTimer;
        private static int shots = 0;


        private int objOldX;
        private int objOldY;

        private int objNewX;
        private int objNewY;

        private bool isPlayerAlive = true;
        //private readonly IMainMenu menu;
        private readonly IMap map;
        private readonly IPlayerTank playerTank;
        private readonly IEnvironmentFactory environmentFactory;
        private readonly ICollision collision;
        private readonly IDisplay display;

        public Engine(IDisplay display, /*IMainMenu menu, */IMap map, IPlayerTank playerTank, IEnvironmentFactory environmentFactory, ICollision collision)
        {
            //this.menu = menu;
            this.map = map;
            this.playerTank = playerTank;
            this.environmentFactory = environmentFactory;
            this.collision = collision;
            this.display = display;
        }


        public void Start()
        {
            gameSettings = new GameSettings(21, 30, new TimeSpan(0, 0, 0, 0, 200), new TimeSpan(0, 0, 0, 0, 600), new TimeSpan(0, 0, 0, 0, 100));

            display.Resize(gameSettings.RowsSize, gameSettings.ColsSize);

            timerGameRefresh = DateTime.Now;
            timerShell = DateTime.Now;

            enemyTanks.Add(environmentFactory.CreateEnemyTank(1, 1, Direction.Left, map, playerTank, environmentFactory, collision));
            enemyTanks.Add(environmentFactory.CreateEnemyTank(2, 20, Direction.Down, map, playerTank, environmentFactory, collision));
            enemyTanks.Add(environmentFactory.CreateEnemyTank(4, 28, Direction.Up, map, playerTank, environmentFactory, collision));
            enemyTanks.Add(environmentFactory.CreateEnemyTank(4, 4, Direction.Right, map, playerTank, environmentFactory, collision));

            playerTank.Shots += new EventHandler(ShotCount);
            playerTank.OnShots();

            //Enemy

            //if (!menu.Run())
            //{
            //    return;
            //}

            display.Print(map);

            //After Start
            while (isPlayerAlive)
            {
                if (ShellSpeed())
                {
                    for (int shell = shells.Count - 1; shell >= 0; shell--)
                    {
                        if (shells[shell].Map == null)
                        {
                            continue;
                        }

                        objOldX = shells[shell].RowPosition;
                        objOldY = shells[shell].ColumnPosition;

                        bool isMoved = shells[shell].Move();

                        objNewX = shells[shell].RowPosition;
                        objNewY = shells[shell].ColumnPosition;

                        if (!isMoved)
                        {
                            shells.Remove(shells[shell]);
                        }

                        if (playerTank.Map == null)
                        {
                            isPlayerAlive = false;
                            return;
                        }

                        display.Update(map, objOldX, objOldY, objNewX, objNewY);
                    }
                    //Shell Move Update

                    if (GameTimePassed())
                    {
                        objOldX = playerTank.RowPosition;
                        objOldY = playerTank.ColumnPosition;
                        if (!Keyboard.IsKeyUp(Key.Space) && ShellTimePassed())
                        {
                            var shell = playerTank.Shoot();

                            if (shell.Map != null)
                            {
                                objNewX = shell.RowPosition;
                                objNewY = shell.ColumnPosition;

                                display.Update(map, objOldX, objOldY, objNewX, objNewY);

                                shells.Add(shell);
                            }
                        }
                        //Shell Shoot Update

                        else if (!Keyboard.IsKeyUp(Key.Up))
                        {
                            var info = playerTank.MoveUp();

                            objNewX = playerTank.RowPosition;
                            objNewY = playerTank.ColumnPosition;

                            display.Update(map, objOldX, objOldY, objNewX, objNewY);
                        }
                        else if (!Keyboard.IsKeyUp(Key.Down))
                        {
                            var info = playerTank.MoveDown();

                            objNewX = playerTank.RowPosition;
                            objNewY = playerTank.ColumnPosition;

                            display.Update(map, objOldX, objOldY, objNewX, objNewY);
                        }
                        else if (!Keyboard.IsKeyUp(Key.Left))
                        {
                            var info = playerTank.MoveLeft();

                            objNewX = playerTank.RowPosition;
                            objNewY = playerTank.ColumnPosition;

                            display.Update(map, objOldX, objOldY, objNewX, objNewY);
                        }
                        else if (!Keyboard.IsKeyUp(Key.Right))
                        {
                            var info = playerTank.MoveRight();

                            objNewX = playerTank.RowPosition;
                            objNewY = playerTank.ColumnPosition;

                            display.Update(map, objOldX, objOldY, objNewX, objNewY);
                        }
                        //Player Tank Update

                        for (int tank = enemyTanks.Count - 1; tank >= 0; tank--)
                        {
                            if (enemyTanks[tank].Map != null)
                            {
                                objOldX = enemyTanks[tank].RowPosition;
                                objOldY = enemyTanks[tank].ColumnPosition;
                                IShell shell = enemyTanks[tank].DetectPlayer();
                                if (shell != null)
                                {
                                    shells.Add(shell);
                                }
                                else if (enemyTanks[tank].Move())
                                {
                                    objNewX = enemyTanks[tank].RowPosition;
                                    objNewY = enemyTanks[tank].ColumnPosition;

                                    display.Update(map, objOldX, objOldY, objNewX, objNewY);
                                }
                            }
                            else
                            {
                                display.Update(map, objOldX, objOldY, objNewX, objNewY);
                                enemyTanks.RemoveAt(tank);
                            }
                        }
                        if (enemyTanks.Count == 0)
                        {
                            //menu.Victory();
                            return;
                        }
                        //Enemy Tanks Update

                        if (map[playerTank.RowPosition, playerTank.ColumnPosition] is Road)
                        {
                            isPlayerAlive = false;
                        }
                    }

                }
            }

            //menu.GameOver();

        }

        private bool ShellSpeed()
        {
            TimeSpan timespan = DateTime.Now - timerShell;
            if (timespan > gameSettings.ShellSpeed)
            {
                timerShell = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GameTimePassed()
        {
            TimeSpan timespan = DateTime.Now - timerGameRefresh;
            if (timespan > gameSettings.RefreshRate)
            {
                timerGameRefresh = DateTime.Now;
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

        private static void ShotCount(object sender, EventArgs args)
        {
            shots++;
        }
    }
}
