using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult AddNumbers(int a, int b, int c)
        {
            int sum = a + b + c;
            return Ok(sum);
        }
    }
}