namespace BattleShip.Entity
{
    public class ShipUnit
    {
        private bool _isHit;
        private int xCordinate;
        private int yCordinate;

        public int XCordinate
        {
            get { return xCordinate; }
            set { xCordinate = value; }
        }

        public int YCordinate
        {
            get { return yCordinate; }
            set { yCordinate = value; }
        }
        public bool IsHit
        {
            get { return _isHit; }
            set { _isHit = value; }
        }
    }
}
