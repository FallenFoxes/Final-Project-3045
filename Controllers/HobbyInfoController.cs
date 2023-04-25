using Final_Project_3045.Data;
using Final_Project_3045.Interfaces;
using Final_Project_3045.Model;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_3045.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HobbyInfoController : ControllerBase
    {

        private readonly ILogger<HobbyInfoController> _logger;

        private readonly IHobbyInfoContextDAO _context;

        public HobbyInfoController(ILogger<HobbyInfoController> logger, IHobbyInfoContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllHobbies());
        }

        [HttpGet("name")]
        public IActionResult Get(int id)
        {
            var hobby = _context.GetHobbyById(id);
            if (hobby == null)
            {
                return NotFound(id);
            }
            return Ok(hobby);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveStudentById(id);
            if (result == null)
                return NotFound();

            if (result == 0)
            {
                return StatusCode(500, "An error ocurred while processing your request");
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(HobbyInfo hobby)
        {
            var result = _context.UpdateHobby(hobby);

            if (result == null)
                return NotFound(hobby.Id);

            if (result == 0)
            {
                return StatusCode(500, "An error ocurred while processing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(HobbyInfo hobby)
        {
            var result = _context.Add(hobby);

            if (result == null)
                return StatusCode(500, "Hobby already exists");
            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }
    }
}
