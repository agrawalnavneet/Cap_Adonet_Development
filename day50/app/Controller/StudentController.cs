using Microsoft.AspNetCore.Mvc;

using app;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    [HttpGet]
    // base GET returns a helpful message rather than 405
    public IActionResult Get()
    {
        return Ok("Use GET /api/student/{name} to reverse a name, or POST JSON { \"name\":\"...\" } to this endpoint.");
    }

    [HttpGet("{name}")]
    // simple GET that accepts a name segment so you can hit it from a browser
    public IActionResult Get(string name)
    {
        var arr = name.ToCharArray();
        Array.Reverse(arr);
        return Ok(new string(arr));
    }

    [HttpPost]
    // original POST action – you must POST JSON { "name":"..." } to this endpoint
    public IActionResult Post(Student student)
    {
        var name = student.Name;

        // Reverse the string
        char[] arr = name.ToCharArray();
        Array.Reverse(arr);

        var reversed = new string(arr);

        return Ok(reversed);
    }
}