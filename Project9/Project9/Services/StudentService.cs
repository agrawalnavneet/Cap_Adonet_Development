using Project9.Models;
using Project9.Repository;

namespace Project9.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _Repo;
        public StudentService(IStudentRepo repo)
        {
            _Repo = repo; 
        }
        public void AddStd(Student s)
        {
            _Repo.Add(s);
        }

        public void DeleteStd(int s)
        {
            _Repo.Delete(s);
        }

        public List<Student> GetStudents()
        {
            return _Repo.GetAll();
        }

        public void UpdateStd(Student s)
        {
            _Repo.Update(s);
        }
    }
}
