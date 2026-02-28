using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Student()
        {
            var s = new { Name = "shivancsh", Marks = 60, Major = "conputer Science" };
            return Json(s); 
        }
        public IActionResult Test()
        {
            return NotFound();
        }
        public IActionResult Square(int? number)
        {
            if(number == null)
            {
                return Content("please provide a number");
            }
            return View(number.Value);
        }
        public IActionResult AddNumber(int? number1, int? number2, int? number3)
        {
            int sum = (number1 ?? 0) + (number2 ?? 0) + (number3 ?? 0);

            ViewBag.Result = sum;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
