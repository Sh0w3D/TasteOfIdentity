using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaseOfIdentity.Services;

namespace TaseOfIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService) => this.studentService = studentService;


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await studentService.List();

            return Ok(students);
        }
    }
}
