using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Arun", M1 = 90, M2 = 95 },
                new Student { Id = 2, Name = "Bala", M1 = 70, M2 = 60 },
                new Student { Id = 3, Name = "Charan", M1 = 50, M2 = 40 }
            };

            var result = students.Select(s => new
            {
                s.Id,
                s.Name,
                s.M1,
                s.M2,
                Total = (s.M1 ?? 0) + (s.M2 ?? 0),
                Grade = CalculateGrade((s.M1 ?? 0) + (s.M2 ?? 0))
            }).ToList();

            return Ok(result);
        }

        private static string CalculateGrade(int total)
        {
            if (total >= 180) return "A";
            if (total >= 150) return "B";
            if (total >= 100) return "C";
            return "Fail";
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? M1 { get; set; }
        public int? M2 { get; set; }
    }
}