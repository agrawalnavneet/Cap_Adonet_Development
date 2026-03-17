using Microsoft.AspNetCore.Mvc;

namespace ConsumerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberController : ControllerBase
    {
        [HttpGet]
        public string GetNumber(int number)
        {
            return $"Received number: {number}";
        }
    }
}