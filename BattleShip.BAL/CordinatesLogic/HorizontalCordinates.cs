using BattleShip.Entity;
using System;
using System.Collections.Generic;

namespace BattleShip.BAL
{
    public class HorizontalCordinates : CordinateBase
    {
        public HorizontalCordinates(Board board) : base(board)
        {

        }
       
        public override List<Tuple<int, int>> GetNextCordinate(int x, int y, int size)
        {
            List<Tuple<int, int>> Cordinates = new List<Tuple<int, int>>();
            if (IsCordinateValid(x, y) && !IsCordinateOccupied(x, y))
            {
                //Add the current cordinate
                Cordinates.Add(new Tuple<int, int>(x, y));
                for (int m = x + 1; m <= x + size - 1; m++)
                {
                    if (!IsCordinateValid(m, y) || IsCordinateOccupied(m, y))
                    {
                        Cordinates = new List<Tuple<int, int>>();
                        return Cordinates;
                    }
                    Cordinates.Add(new Tuple<int, int>(m, y));
                }
            }
            return Cordinates;
        }

    }
}
