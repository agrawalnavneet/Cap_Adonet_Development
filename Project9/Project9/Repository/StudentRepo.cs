using Project9.Data;
using Project9.Models;

namespace Project9.Repository
{
    public class StudentRepo:IStudentRepo
    {
        private readonly AppDbContext _context;
        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Student s)
        {
            _context.Students.Add(s);
            _context.SaveChanges();
        }

        public void Delete(int s)
        {
            var std = _context.Students.Find(s);
            if (std != null)
            {
                _context.Students.Remove(std);
                _context.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public void Update(Student s)
        {
            _context.Students.Update(s);
            _context.SaveChanges();
        }
    }
}
