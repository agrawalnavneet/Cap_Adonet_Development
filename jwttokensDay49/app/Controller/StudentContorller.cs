using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetStudents()
    {
        return Ok(new string[]
        {
            "Arun",
            "Divya",
            "Rahul"
        });
    }
}