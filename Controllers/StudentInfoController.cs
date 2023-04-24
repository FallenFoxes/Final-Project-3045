using Microsoft.AspNetCore.Mvc;


namespace Final_Project_3045.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentInfoController : ControllerBase
    {     

        private readonly ILogger<StudentInfoController> _logger;

        public StudentInfoController(ILogger<StudentInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
