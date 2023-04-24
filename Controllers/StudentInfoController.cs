using Final_Project_3045.Data;
using Final_Project_3045.Model;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_3045.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentInfoController : ControllerBase
    {     

        private readonly ILogger<StudentInfoController> _logger;

        private readonly StudentInfoContext _context;

        public StudentInfoController(ILogger<StudentInfoController> logger, StudentInfoContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllStudents);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var student = _context.GetStudentById(id);
            if (student == null)
            {
                return NotFound(id);
            }
            return Ok(student);
        }
    }
}
