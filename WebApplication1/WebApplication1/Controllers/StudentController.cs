using Microsoft.AspNetCore.Mvc;
using MVCwithADO.Data;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repo;
        private readonly ILogger<StudentController> _logger;

        public StudentController(StudentRepository repo, ILogger<StudentController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var students = _repo.GetAllStudents();
                return View(students);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed to load students for Index view.");
                return View(new List<MVCwithADO.Models.Student>());
            }
        }
    }
}
