using BattleShip.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.BAL
{
    public abstract class CordinateBase
    {
        public Board _board = new Board();
        public CordinateBase(Board board)
        {
            _board = board;
        }
        public List<Tuple<int, int>> GetCordinate(int size)
        {
            List<Tuple<int, int>> Cordinates = new List<Tuple<int, int>>();
            if (!IsSizeValid(size))
                return Cordinates;
            int x = _board.BoardMeasurement.GetLength(0);
            int y = _board.BoardMeasurement.GetLength(1);

            int xBorder = 1;
            int yBorder = 1;

            int max = x * y;

            for (int i = 1; i <= max; i++)
            {
                int xCordinate = xBorder;
                int yCordinate = yBorder;

                Cordinates = GetNextCordinate(xBorder, yBorder, size);
                if (Cordinates.Count > 0)
                    return Cordinates;

                if (i % y == 0)
                {
                    xBorder = 1;
                    yBorder += 1;
                }
                else
                {
                    xBorder += 1;
                }
            }

            return Cordinates;
        }
        public abstract List<Tuple<int, int>> GetNextCordinate(int x, int y, int size);

        public bool IsCordinateOccupied(int xCordinate, int yCordinate)
        {            
            foreach (Ship s in _board.ListShips)
            {
                foreach (ShipUnit su in s.listShipUnit)
                {
                    if (su.XCordinate == xCordinate && su.YCordinate == yCordinate)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsCordinateValid(int xCordinate, int yCordinate)
        {
            if (xCordinate > _board.BoardMeasurement.GetLength(0))
                return false;
            if (yCordinate > _board.BoardMeasurement.GetLength(1))
                return false;

            return true;
        }

        public bool IsSizeValid(int size)
        {
            if (size > _board.BoardMeasurement.GetLength(0))
                return false;
            return true;
        }
    }
}
