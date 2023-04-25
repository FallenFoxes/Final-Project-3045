using Final_Project_3045.Data;
using Final_Project_3045.Interfaces;
using Final_Project_3045.Model;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_3045.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameInfoController : ControllerBase
    {

        private readonly ILogger<GameInfoController> _logger;

        private readonly IGameInfoContextDAO _context;

        public GameInfoController(ILogger<GameInfoController> logger, IGameInfoContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllGames());
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var game = _context.GetGameById(id);
            if (game == null)
            {
                return NotFound(id);
            }
            return Ok(game);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveGameById(id);
            if (result == null)
                return NotFound();

            if (result == 0)
            {
                return StatusCode(500, "An error ocurred while processing your request");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(GameInfo game)
        {
            var result = _context.UpdateGame(game);

            if (result == null)
                return NotFound(game.Id);

            if (result == 0)
            {
                return StatusCode(500, "An error ocurred while processing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(GameInfo game)
        {
            var result = _context.Add(game);

            if (result == null)
                return StatusCode(500, "Game already exists");
            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }
    }
}
