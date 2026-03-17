using Microsoft.AspNetCore.Mvc;

namespace ProducerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendController : ControllerBase
    {
        [HttpGet("{number}")]
        public async Task<string> SendNumber(int number)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(
                "http://localhost:5278/api/number?number=" + number);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}