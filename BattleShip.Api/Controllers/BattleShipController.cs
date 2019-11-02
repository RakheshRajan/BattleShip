﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShip.BAL;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [HttpGet("CreateShip")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "This is a test method", "This is a test method" };
        }

        // POST api/values
        [HttpPost("CreateShip/{size}/{direction}")]
        [HttpPost("CreateShip/{size}/{direction}/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateShip(int size, string direction, string name = "System")
        {
            string message = string.Empty;
            try
            {
                message = _gameManager.AddShip(size, direction,name);
                return StatusCode(StatusCodes.Status200OK, new { message = message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        // POST api/values
        [HttpGet("Fire")]
        public string Get(int x, int y, string playerName = "System")
        {
            string message = "This is a test method";
            return message;
        }

        // POST api/values
        [HttpPost("Fire/{x}/{y}")]
        [HttpPost("Fire/{x}/{y}/{playerName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Fire(int x, int y, string playerName = "System")
        {
            string message = string.Empty;
            try
            {
                message = _gameManager.Fire(x, y, playerName);
                return StatusCode(StatusCodes.Status200OK, new { message = message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost("RestartGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RestartGame()
        {
            try
            {
                _gameManager.DeleteUsers();
                _gameManager.CreateUser();
                return StatusCode(StatusCodes.Status200OK, new { message = "Game Restarted" });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }            
        } 
    }
}
