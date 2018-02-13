using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using AlphaTank.Program.Contracts;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.GameEngine.ControlProvider;
using AlphaTank.Program.GameEngine.TimerProvider;
using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.GameEngine.DataProvider;

namespace AlphaTank.Program.GameEngine
{
    public class Engine
    {

        private static int shots = 0;

        //private readonly IMainMenu menu;
        private readonly IMap map;
        private readonly IPlayerTank playerTank;
        private readonly IEnvironmentFactory environmentFactory;
        private readonly ICollision collision;
        private readonly IKeyboardWraper keyboard;
        private readonly IGameTimer timer;
        private readonly IGameSettings gameSettings;
        private readonly IData data;
        private readonly IDisplay display;



        public Engine(IDisplay display, /*IMainMenu menu, */IMap map, IPlayerTank playerTank, IEnvironmentFactory environmentFactory, ICollision collision, IKeyboardWraper keyboard, IGameTimer timer, IGameSettings gameSettings, IData data)
        {
            //this.menu = menu;
            this.map = map ?? throw new NoMapException();
            this.playerTank = playerTank ?? throw new ArgumentNullException();
            this.environmentFactory = environmentFactory ?? throw new ArgumentNullException();
            this.collision = collision ?? throw new ArgumentNullException();
            this.keyboard = keyboard ?? throw new ArgumentNullException();
            this.timer = timer ?? throw new ArgumentNullException();
            this.gameSettings = gameSettings ?? throw new ArgumentNullException();
            this.data = data;
            this.display = display ?? throw new ArgumentNullException();
        }

        public void Start()
        {
            this.display.Resize(this.gameSettings.RowsSize, this.gameSettings.ColsSize);

            this.data.EnemyTanks.Add(environmentFactory.CreateEnemyTank(1, 1, Direction.Left));
            this.data.EnemyTanks.Add(environmentFactory.CreateEnemyTank(2, 20, Direction.Down));
            this.data.EnemyTanks.Add(environmentFactory.CreateEnemyTank(4, 28, Direction.Up));
            this.data.EnemyTanks.Add(environmentFactory.CreateEnemyTank(4, 4, Direction.Right));

            this.playerTank.Shots += new EventHandler(ShotCount);
            this.playerTank.OnShots();

            //Enemy

            //if (!menu.Run())
            //{
            //    return;
            //}

            this.display.Print();

            //After Start
            while (this.gameSettings.IsPlayerAlive)
            {
                if (this.timer.ShellSpeed())
                {
                    for (int shell = this.data.Shells.Count - 1; shell >= 0; shell--)
                    {
                        if (this.data.Shells[shell].Map == null)
                        {
                            continue;
                        }

                        this.display.OldX = this.data.Shells[shell].RowPosition;
                        this.display.OldY = this.data.Shells[shell].ColumnPosition;

                        bool isMoved = this.data.Shells[shell].Move();

                        this.display.NewX = this.data.Shells[shell].RowPosition;
                        this.display.NewY = this.data.Shells[shell].ColumnPosition;

                        if (!isMoved)
                        {
                            this.data.Shells.Remove(this.data.Shells[shell]);
                        }

                        if (this.playerTank.Map == null)
                        {
                            this.gameSettings.IsPlayerAlive = false;
                            return;
                        }

                        this.display.Update();
                    }
                    //Shell Move Update

                    if (this.timer.GameTimePassed())
                    {
                        this.display.OldX = playerTank.RowPosition;
                        this.display.OldY = playerTank.ColumnPosition;

                        if (!this.keyboard.IsKeyUp(Key.Space) && this.timer.ShellCooldownPassed())
                        {
                            var shell = this.playerTank.Shoot();

                            if (shell.Map != null)
                            {
                                this.display.NewX = shell.RowPosition;
                                this.display.NewY = shell.ColumnPosition;

                                this.display.Update();

                                this.data.Shells.Add(shell);
                            }
                        }
                        //Shell Shoot Update

                        else if (!this.keyboard.IsKeyUp(Key.Up))
                        {
                            var info = this.playerTank.MoveUp();

                            this.display.NewX = this.playerTank.RowPosition;
                            this.display.NewY = this.playerTank.ColumnPosition;

                            this.display.Update();
                        }
                        else if (!this.keyboard.IsKeyUp(Key.Down))
                        {
                            var info = this.playerTank.MoveDown();

                            this.display.NewX = this.playerTank.RowPosition;
                            this.display.NewY = this.playerTank.ColumnPosition;

                            this.display.Update();
                        }
                        else if (!this.keyboard.IsKeyUp(Key.Left))
                        {
                            var info = this.playerTank.MoveLeft();

                            this.display.NewX = this.playerTank.RowPosition;
                            this.display.NewY = this.playerTank.ColumnPosition;

                            this.display.Update();
                        }
                        else if (!this.keyboard.IsKeyUp(Key.Right))
                        {
                            var info = this.playerTank.MoveRight();

                            this.display.NewX = this.playerTank.RowPosition;
                            this.display.NewY = this.playerTank.ColumnPosition;

                            this.display.Update();
                        }
                        //Player Tank Update

                        for (int tank = this.data.EnemyTanks.Count - 1; tank >= 0; tank--)
                        {
                            if (this.data.EnemyTanks[tank].Map != null)
                            {
                                this.display.OldX = this.data.EnemyTanks[tank].RowPosition;
                                this.display.OldY = this.data.EnemyTanks[tank].ColumnPosition;

                                IShell shell = this.data.EnemyTanks[tank].DetectPlayer();

                                if (shell != null)
                                {
                                    this.data.Shells.Add(shell);
                                }
                                else if (this.data.EnemyTanks[tank].Move())
                                {
                                    this.display.NewX = this.data.EnemyTanks[tank].RowPosition;
                                    this.display.NewY = this.data.EnemyTanks[tank].ColumnPosition;

                                    this.display.Update();
                                }
                            }
                            else
                            {
                                this.display.Update();
                                this.data.EnemyTanks.RemoveAt(tank);
                            }
                        }
                        if (this.data.EnemyTanks.Count == 0)
                        {
                            //menu.Victory();
                            return;
                        }
                        //Enemy Tanks Update

                        if (this.map[this.playerTank.RowPosition, this.playerTank.ColumnPosition] is Road)
                        {
                            this.gameSettings.IsPlayerAlive = false;
                        }
                    }
                }
            }

            //menu.GameOver();
        }


        private static void ShotCount(object sender, EventArgs args)
        {
            shots++;
        }
    }
}
