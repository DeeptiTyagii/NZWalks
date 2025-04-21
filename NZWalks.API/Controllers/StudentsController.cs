using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    //https://localhost:port/api/controllername (which is Students in this case)
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET:https://localhost:port/api/Students
        [HttpGet] //annotate with an http attribute
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "DT", "John", "Alex", "Abhishek", "Steve", "Deval", "ZoAnne" };

            return Ok(studentNames);
        }
    }
}
