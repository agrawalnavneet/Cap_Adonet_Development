using Project9.Models;
using Project9.Data;

namespace Project9.Repository
{
    public interface IStudentRepo
    {

        public List<Student> GetAll();
        public void Add(Student s);
        public void Update(Student s);
        public void Delete(int s);
        
    }
}
