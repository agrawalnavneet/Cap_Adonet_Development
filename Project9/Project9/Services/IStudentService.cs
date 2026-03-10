using Project9.Models;

namespace Project9.Services
{
    public interface IStudentService
    {
        public List<Student> GetStudents();
        public void AddStd(Student s);
        public void UpdateStd(Student s);
        public void DeleteStd(int s);
    }
}
