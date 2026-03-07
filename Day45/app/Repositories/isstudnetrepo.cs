
using app.Models;
public interface IStudentRepository
{
    List<Student> GetAllStudents();
    void AddStudent(Student student);
}