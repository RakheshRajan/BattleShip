using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShip.BAL;
using Microsoft.AspNetCore.Mvc;

namespace BattleShip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleShipController : ControllerBase
    {
        private readonly IGameManager _gameManager;

        public BattleShipController(IGameManager gameManager)
        {
            this._gameManager = gameManager;
        }        

        // POST api/values
        [HttpPost("CreateShip/{size}/{direction}")]
        public string CreateShip(int size, string direction)
        {
            string message = _gameManager.AddShip(size, direction);
            return message;
        }

        // POST api/values
        [HttpPost("Fire/{x}/{y}")]
        [HttpPost("Fire/{x}/{y}/{Fire}")]
        public string Fire(int x, int y, string playerName = "System")
        {
            string message = _gameManager.Fire(x, y, playerName);
            return message;
        }

        [HttpPost("RestartGame")]
        public string RestartGame()
        {
            _gameManager.DeleteUsers();
            _gameManager.CreateUser();
            return "Game Restarted";
        } 
    }
}
