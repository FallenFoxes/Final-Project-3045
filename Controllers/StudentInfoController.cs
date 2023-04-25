using Final_Project_3045.Data;
using Final_Project_3045.Interfaces;
using Final_Project_3045.Model;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_3045.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentInfoController : ControllerBase
    {     

        private readonly ILogger<StudentInfoController> _logger;

        private readonly IStudentInfoContextDAO _context;

        public StudentInfoController(ILogger<StudentInfoController> logger, IStudentInfoContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAllStudents());
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
        public IActionResult Put(StudentInfo student)
        {
            var result = _context.UpdateStudent(student);

            if (result == null)
                return NotFound(student.Id);

            if (result == 0)
            {
                return StatusCode(500, "An error ocurred while processing your request");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(StudentInfo student)
        {
            var result = _context.Add(student);

            if (result == null)
                return StatusCode(500, "Student already exists");
            if (result == 0)
                return StatusCode(500, "An error occurred while processing your request");

            return Ok();
        }
    }
}
