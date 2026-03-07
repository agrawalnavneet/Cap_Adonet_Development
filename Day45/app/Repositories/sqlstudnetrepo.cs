using System.Collections.Generic;
using System.Linq;
using app.Data;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public SqlStudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            // ensure database is created/migrated as needed
            return _context.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}
