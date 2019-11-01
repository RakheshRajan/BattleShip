using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Entity
{
    public class Ship
    {
        private int _id;
        private ShipDirection _shipDirection;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public ShipDirection ShipDirection
        {
            get { return _shipDirection; }
            set { _shipDirection = value; }
        }        
        public bool IsSunk
        {
            get; set;
        }
        public List<ShipUnit> listShipUnit = new List<ShipUnit>();
    }
}
