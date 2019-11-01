using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.BAL
{
    public interface IGameManager
    {
        string CreateUser(string playerName = "System");
        string AddShip(int size, string direction, string name = "System");
        string Fire(int xCordinate, int yCordinate, string name = "System");
        string DeleteUsers();
    }
}
