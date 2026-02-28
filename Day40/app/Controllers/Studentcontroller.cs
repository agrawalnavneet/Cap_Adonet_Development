using EFCodefirstMVC.Data;
using app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;

namespace EFCodeFirstMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentManagementContext _context;

        public StudentsController(StudentManagementContext context)
        {
            _context = context;
        }


        public IActionResult Create(string name, float age, string city)
        {
            var student = new Student
            {
                Name = name,
                Age = age,
                City = city
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            

            return Content("Student Created Successfully");
        }}}