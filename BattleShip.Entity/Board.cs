using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Entity
{
    public class Board
    {
        private List<Ship> _listShips;
        public readonly int[,] BoardMeasurement=new int[10,10];

        public List<Ship> ListShips
        {
            get { return _listShips; }
            set { _listShips = value; }
        }
    }
}
