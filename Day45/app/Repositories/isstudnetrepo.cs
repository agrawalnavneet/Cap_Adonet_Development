using System.Collections.Generic;
using app.Models;

namespace app.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
    }
}
