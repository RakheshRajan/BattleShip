using BattleShip.Entity;
using System;
using System.Collections.Generic;

namespace BattleShip.BAL
{
    public class GameManager : IGameManager
    {
        //private static readonly object padlock = new object();
        public List<Player> players = new List<Player>();

        public GameManager()
        {
            //Create a default user and settings;
            CreateUser();
        }


        /// <summary>
        /// Create the user with default board and ship
        /// </summary>
        /// <param name="playerName">Optional parameter - If not specifid it will add the default system user.</param>
        public string CreateUser(string playerName = "System")
        {
            int id = players.Count;
            //Create Player with default settings. 
            Player player = new Player(id, playerName, new Board());
            player.PlayerBoard.ListShips = new List<Ship>();
            player.Name = playerName;
            player.IsGameCompleted = false;
            players.Add(player);
            return "Player added succesfully";
        }

        /// <summary>
        /// Create the user with default board and ship
        /// </summary>
        /// <param name="playerName">Optional parameter - If not specifid it will add the default system user.</param>
        public string DeleteUsers()
        {
            players = new List<Player>();
            return "Players removed succesfully";
        }

        /// <summary>
        /// This method is to add a ship to the avialable cordinates based on the size requested. Ship will be allocated 
        /// under the system user if user name is not passed else it will be allocated under the passed user name.
        /// </summary>
        /// <param name="size">how many units the ship is going to Occupy</param>
        /// <param name="direction">Parallel or Horizontal alignment?</param>
        /// <param name="name">Name of the player. If not specified it will add ship to the default player.</param>

        public string AddShip(int size, string direction, string name = "System")
        {
            List<Tuple<int, int>> cordinates = new List<Tuple<int, int>>();
            CordinateBase cordinateBase;
            ShipDirection shipDirection;
            int index = 0;
            bool isUserCreated = false;
            string message = string.Empty;
            direction = direction.ToLower();

            foreach (Player p in players)
            {
                if (p.Name == name)
                {
                    isUserCreated = true;
                    index = p.Id;
                }
            }

            if (!isUserCreated)
            {
                CreateUser(name);
                index = players.Count - 1;
            }

            switch (direction)
            {
                case "v":
                    shipDirection = ShipDirection.Vertical;
                    cordinateBase = new VerticalCordinates(players[index].PlayerBoard);
                    break;
                case "h":
                    shipDirection = ShipDirection.Horizontal;
                    cordinateBase = new HorizontalCordinates(players[index].PlayerBoard);
                    break;
                default:
                    shipDirection = ShipDirection.Horizontal;
                    cordinateBase = new HorizontalCordinates(players[index].PlayerBoard);
                    break;
            }

            cordinates = cordinateBase.GetCordinate(size);

            if (cordinates.Count > 0)
            {
                Ship ship = new Ship();
                ship.IsSunk = false;
                ship.Id = players[index].PlayerBoard.ListShips.Count + 1;
                ship.ShipDirection = shipDirection;
                ship.listShipUnit = CreateShipUnits(cordinates);

                players[index].PlayerBoard.ListShips.Add(ship);

                message = "Ship added to the board : ";
                foreach (Tuple<int, int> t in cordinates)
                {
                    message += " X - " + t.Item1 + " , Y - " + t.Item2 + " ; ";
                }
            }
            else
            {
                message = "No units available in the board";
            }

            return message;
        }

        private List<ShipUnit> CreateShipUnits(List<Tuple<int, int>> cordinates)
        {
            List<ShipUnit> listShipUnits = new List<ShipUnit>();
            foreach (Tuple<int, int> t in cordinates)
            {
                ShipUnit shipUnit = new ShipUnit();
                shipUnit.IsHit = false;
                shipUnit.XCordinate = t.Item1;
                shipUnit.YCordinate = t.Item2;
                listShipUnits.Add(shipUnit);
            }
            return listShipUnits;
        }
        /// <summary>
        /// Fire at the cordinates of users board. User Name if not passed, system user's board will be taken by default.
        /// </summary>
        /// <param name="xCordinate"> X Cordinate</param>
        /// <param name="yCordinate">Y Cordinate</param>
        /// <param name="name">User Name</param>
        /// <returns></returns>
        public string Fire(int xCordinate, int yCordinate, string name = "System")
        {
            int index = 0;
            int shipId = 0;
            bool isSung = true;
            bool isWon = true;
            bool isHit = false;
            string message = string.Empty;
            foreach (Player p in players)
            {
                if (p.Name == name)
                {
                    if (p.IsGameCompleted)
                    {
                        message = "Game is already completed. Please restart the game to continue playing.";
                        return message;
                    }
                    if (p.PlayerBoard.ListShips.Count <= 0)
                    {
                        message = "No ships placed in the board.";
                        return message;
                    }
                    index = p.Id;
                    foreach (Ship s in p.PlayerBoard.ListShips)
                    {
                        foreach (ShipUnit su in s.listShipUnit)
                        {
                            if (su.XCordinate == xCordinate && su.YCordinate == yCordinate)
                            {
                                shipId = s.Id - 1;
                                if (su.IsHit)
                                {
                                    message = "This unit is already hit.";
                                    return message;
                                }

                                su.IsHit = true;
                                isHit = true;
                                message = "It is a hit.";
                                break;
                            }
                        }
                    }
                }
            }
            foreach (ShipUnit su in players[index].PlayerBoard.ListShips[shipId].listShipUnit)
            {
                if (!su.IsHit) { isSung = false; }
            }
            if (isSung)
            {
                players[index].PlayerBoard.ListShips[shipId].IsSunk = true;
                message += " 1 Ship has been sunk.";
            }

            foreach (Ship s in players[index].PlayerBoard.ListShips)
            {
                if (!s.IsSunk) { isWon = false; }
            }

            if (isWon)
            {
                players[index].IsGameCompleted = true;
                message += " All battleships are sunk. Congratulations you have won the game.";
            }
            if (!isHit)
                message = "It is a miss hit.";
            return message;
        }
    }
}