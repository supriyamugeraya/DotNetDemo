using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDemo.API.Controllers
{

    //https://localhost:portnumber(7032)/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: https://localhost:portnumber(7032)/api/student
        [HttpGet]
        public IActionResult GetAllStudents()

        {
            string[] StudentName = new string[] { "supriya", "sumana", "varun", "shreyaan", "manasvi" };
            return Ok(StudentName);
        }
    }
}
