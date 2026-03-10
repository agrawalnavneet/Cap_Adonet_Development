using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Project9.Services;
using Project9.Models;

namespace Project9.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _Service;
        public StudentController(IStudentService service)
        {
            _Service = service;
        }
        public IActionResult Index()
        {
            var std=_Service.GetStudents();
            return View(std);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student s)
        {
            _Service.AddStd(s);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var std = _Service.GetStudents().FirstOrDefault(x => x.StudentId == id);
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            _Service.UpdateStd(std);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _Service.DeleteStd(id);
            return RedirectToAction("Index");
        }

    }
}
