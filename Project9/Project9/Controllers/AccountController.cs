using Microsoft.AspNetCore.Mvc;
using Project9.Data;
using Project9.Models;

namespace Project9.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // Login page
        public IActionResult Login()
        {
            return View();
        }

        // Login POST
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var student = _context.Students
                .FirstOrDefault(x => x.Email == email && x.Password == password);

            if (student == null)
            {
                ViewBag.Error = "Invalid login";
                return View();
            }

            HttpContext.Session.SetInt32("StudentId", student.StudentId);

            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            var id = HttpContext.Session.GetInt32("StudentId");

            if (id == null)
            {
                return RedirectToAction("Login");
            }

            var student = _context.Students.FirstOrDefault(x => x.StudentId == id);

            return View(student);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}