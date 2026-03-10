using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.DTOs;

namespace app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        static List<Student> students = new List<Student>();

        // POST create student
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO dto)
        {
            var student = new Student
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age
            };

            students.Add(student);

            return Ok(student);
        }

        // PUT update marks
        [HttpPut("{id}")]
        public IActionResult UpdateMarks(int id, UpdateMarksDTO dto)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            student.M1 = dto.M1;
            student.M2 = dto.M2;

            return Ok(student);
        }

        // GET result
        [HttpGet("{id}")]
        public IActionResult GetResult(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            int total = student.M1 + student.M2;

            string grade = "F";

            if (total >= 160) grade = "A";
            else if (total >= 120) grade = "B";
            else if (total >= 80) grade = "C";

            var result = new ResultDTO
            {
                Id = student.Id,
                Name = student.Name,
                M1 = student.M1,
                M2 = student.M2,
                Total = total,
                Grade = grade
            };

            return Ok(result);
        }
    }
}