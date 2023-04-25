using Final_Project_3045.Data;
using Final_Project_3045.Interfaces;
using Final_Project_3045.Model;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_3045.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicInfoController : ControllerBase
    {

        private readonly ILogger<MusicInfoController> _logger;

        private readonly IMusicInfoContextDAO _context;

        public MusicInfoController(ILogger<MusicInfoController> logger, IMusicInfoContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllMusic());
        }

        [HttpGet("name")]
        public IActionResult Get(int id)
        {
            var music = _context.GetMusicById(id);
            if (music == null)
            {
                return NotFound(id);
            }
            return Ok(music);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveMusicById (id);
            if (result == null)
                return NotFound();

            if (result == 0)
            {
                return StatusCode(500, "An error ocurred while processing your request");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(MusicInfo music)
        {
            var result = _context.UpdateMusic(music);

            if (result == null)
                return NotFound(music.Id);

            if (result == 0)
            {
                return StatusCode(500, "An error ocurred while processing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(MusicInfo music)
        {
            var result = _context.Add(music);

            if (result == null)
                return StatusCode(500, "Music already exists");
            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }
    }
}
