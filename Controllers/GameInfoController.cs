using Final_Project_3045.Data;
using Final_Project_3045.Model;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_3045.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GameInfoController : ControllerBase
    {
        private readonly ILogger<GameInfoController> _logger;
        private readonly GameInfoContext _context;
        public GameInfoController(ILogger<GameInfoController> logger, GameInfoContext context)
        {
            _logger= logger;
            _context= context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllGames);
        }
    }
}
