using System;

namespace BattleShip.Entity
{
    public class Player
    {
        private string _name;
        private int _id;
        private Board _playerBoard;
        private bool _isGameCompleted;        

        public bool IsGameCompleted
        {
            get { return _isGameCompleted; }
            set { _isGameCompleted = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Board PlayerBoard
        {
            get { return _playerBoard; }
            set { _playerBoard = value; }
        }

        public Player(int id, string name, Board board)
        {
            Id = id;
            Name = name;
            PlayerBoard = board;
        }
    }
}
