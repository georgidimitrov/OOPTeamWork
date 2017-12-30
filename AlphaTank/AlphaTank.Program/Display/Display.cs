using AlphaTank.Program.Display.Contracts;
using AlphaTank.Program.Models;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using AlphaTank.Program.Models.GameObjects.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace AlphaTank.Program.Display
{
    public class Display
    {
        //Fields
        private static readonly Display instance = new Display();

        //Ctors
        private Display()
        {
        }

        //Props
        public static Display Instance { get { return instance; } }


        //Methods
        public void Resize()
        {
            Console.CursorVisible = false;
            Console.SetBufferSize(30, 21);
            Console.SetWindowSize(30, 21);
        }

        public void Print(Map map)
        {
            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < map.GetMap.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < map.GetMap.GetLength(1); col++)
                {
                    Console.ForegroundColor = map.GetMap[row, col].Color;
                    Console.Write(map.GetMap[row, col].Representative);
                }
            }
        }

        public void Update(Map map, IMovableGameObject gameObj, ICollisionInfo info)
        {
            switch (gameObj.Type)
            {
                case GameObjectType.EnemyTank:
                    if (info.IsCollided)
                    {
                        switch (info.Type)
                        {
                            case GameObjectType.Road:
                                break;
                            case GameObjectType.Obstacle:

                                break;
                            case GameObjectType.EnemyTank:
                                break;
                            case GameObjectType.Shell:
                                break;
                            case GameObjectType.PlayerTank:
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {

                    }
                    break;
                case GameObjectType.Shell:
                    if (info.IsCollided)
                    {
                        switch (info.Type)
                        {
                            case GameObjectType.Obstacle:
                                Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition);
                                Console.Write(map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition].Representative);
                                break;
                            case GameObjectType.EnemyTank:
                                switch (gameObj.Direction)
                                {
                                    case Direction.Up:
                                        Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition - 1);
                                        Console.Write(map.GetMap[gameObj.RowPosition - 1, gameObj.ColumnPosition].Representative);
                                        break;
                                    case Direction.Right:
                                        Console.SetCursorPosition(gameObj.ColumnPosition + 1, gameObj.RowPosition);
                                        Console.Write(map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition + 1].Representative);
                                        break;
                                    case Direction.Down:
                                        Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition + 1);
                                        Console.Write(map.GetMap[gameObj.RowPosition + 1, gameObj.ColumnPosition].Representative);
                                        break;
                                    case Direction.Left:
                                        Console.SetCursorPosition(gameObj.ColumnPosition - 1, gameObj.RowPosition);
                                        Console.Write(map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition - 1].Representative);
                                        break;
                                    default:
                                        break;
                                }
                                Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition);
                                Console.Write(map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition].Representative);
                                break;
                            case GameObjectType.Shell:
                                break;
                            case GameObjectType.PlayerTank:
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (gameObj.Direction)
                        {
                            case Direction.Up:
                                Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition + 1);
                                Console.ForegroundColor = map.GetMap[gameObj.RowPosition + 1, gameObj.ColumnPosition].Color;
                                Console.Write(map.GetMap[gameObj.RowPosition + 1, gameObj.ColumnPosition].Representative);
                                break;
                            case Direction.Right:
                                Console.SetCursorPosition(gameObj.ColumnPosition - 1, gameObj.RowPosition);
                                Console.ForegroundColor = map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition - 1].Color;
                                Console.Write(map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition - 1].Representative);
                                break;
                            case Direction.Down:
                                Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition - 1);
                                Console.ForegroundColor = map.GetMap[gameObj.RowPosition - 1, gameObj.ColumnPosition].Color;
                                Console.Write(map.GetMap[gameObj.RowPosition - 1, gameObj.ColumnPosition].Representative);
                                break;
                            case Direction.Left:
                                Console.SetCursorPosition(gameObj.ColumnPosition + 1, gameObj.RowPosition);
                                Console.ForegroundColor = map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition + 1].Color;
                                Console.Write(map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition + 1].Representative);
                                break;

                            default:
                                break;
                        }

                        Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition);
                        Console.ForegroundColor = gameObj.Color;
                        Console.Write(gameObj.Representative);
                    }
                    break;
                case GameObjectType.PlayerTank:
                    if (info.IsCollided)
                    {
                        //switch (info.Type)
                    }
                    else
                    {
                        switch (gameObj.Direction)
                        {
                            case Direction.Up:
                                Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition + 1);
                                Console.ForegroundColor = map.GetMap[gameObj.RowPosition + 1, gameObj.ColumnPosition].Color;
                                Console.Write(map.GetMap[gameObj.RowPosition + 1, gameObj.ColumnPosition].Representative);
                                break;
                            case Direction.Right:
                                Console.SetCursorPosition(gameObj.ColumnPosition - 1, gameObj.RowPosition);
                                Console.ForegroundColor = map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition - 1].Color;
                                Console.Write(map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition - 1].Representative);
                                break;
                            case Direction.Down:
                                Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition - 1);
                                Console.ForegroundColor = map.GetMap[gameObj.RowPosition - 1, gameObj.ColumnPosition].Color;
                                Console.Write(map.GetMap[gameObj.RowPosition - 1, gameObj.ColumnPosition].Representative);
                                break;
                            case Direction.Left:
                                Console.SetCursorPosition(gameObj.ColumnPosition + 1, gameObj.RowPosition);
                                Console.ForegroundColor = map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition + 1].Color;
                                Console.Write(map.GetMap[gameObj.RowPosition, gameObj.ColumnPosition + 1].Representative);
                                break;

                            default:
                                break;
                        }

                        Console.SetCursorPosition(gameObj.ColumnPosition, gameObj.RowPosition);
                        Console.ForegroundColor = gameObj.Color;
                        Console.Write(gameObj.Representative);
                    }
                    break;
            }
        }
    }
}
