using System.Collections.Generic;
using app.Models;

namespace app.Repositories
{
    public class ListStudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>()
        {
            new Student { Id = 1, Name = "Arun", M1 = 80, M2 = 90 },
            new Student { Id = 2, Name = "Bala", M1 = 70, M2 = 85 }
        };

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
}
