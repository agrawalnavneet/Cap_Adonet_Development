// using app.DTOs;
// using app.Models;
// using Microsoft.EntityFrameworkCore;


// namespace app.Services{
// public class StudentService : IStudentService
// {
//     private readonly CollegeDb1Context _context;

//     public StudentService(CollegeDb1Context context)
//     {
//         _context = context;
//     }

//     public async Task AddStudent(StudentDTO dto)
//     {
//         var hostel = new Hostel
//         {
//             HostelName = dto.HostelName
//         };

//         _context.Hostels.Add(hostel);
//         await _context.SaveChangesAsync();

//         var student = new Student
//         {
//             StudentName = dto.StudentName,
//             HostelId = hostel.HostelId
//         };

//         _context.Students.Add(student);
//         await _context.SaveChangesAsync();
//     }

//     public async Task UpdateStudent(int id, StudentDTO dto)
//     {
//         var student = await _context.Students.FindAsync(id);

//         if (student == null) return;

//         student.StudentName = dto.StudentName;

//         await _context.SaveChangesAsync();
//     }

//     public async Task DeleteStudent(int id)
//     {
//         var student = await _context.Students.FindAsync(id);

//         if (student != null)
//         {
//             _context.Students.Remove(student);
//             await _context.SaveChangesAsync();
//         }
//     }

//     public async Task<List<StudentDTO>> GetAllStudents()
//     {
//         return await _context.Students
//         .Select(s => new StudentDTO
//         {
//             StudentName = s.StudentName
//         }).ToListAsync();
//     }

//     public async Task<List<StudentDTO>> GetStudentsWithHostel()
//     {
//         return await _context.Students
//         .Include(s => s.Hostel)
//         .Select(s => new StudentDTO
//         {
//             StudentName = s.StudentName,
//             HostelName = s.Hostel.HostelName
//         }).ToListAsync();
//     }
// }}


using app.DTOs;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Services
{
    public class StudentService : IStudentService
    {
        private readonly CollegeDb1Context _context;

        public StudentService(CollegeDb1Context context)
        {
            _context = context;
        }

        public async Task CreateStudent(CreateStudentDTO dto)
        {
            var hostel = new Hostel
            {
                HostelName = dto.HostelName
            };

            _context.Hostels.Add(hostel);
            await _context.SaveChangesAsync();

            var student = new Student
            {
                StudentName = dto.StudentName,
                HostelId = hostel.HostelId
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudent(int id, UpdateStudentDTO dto)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null) return;

            student.StudentName = dto.StudentName;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<StudentResponseDTO>> GetAllStudents()
        {
            return await _context.Students
                .Include(s => s.Hostel)
                .Select(s => new StudentResponseDTO
                {
                    StudentName = s.StudentName,
                    HostelName = s.Hostel.HostelName
                })
                .ToListAsync();
        }

        public async Task<List<StudentResponseDTO>> GetStudentsByHostel(string hostelName)
        {
            return await _context.Students
                .Include(s => s.Hostel)
                .Where(s => s.Hostel.HostelName == hostelName)
                .Select(s => new StudentResponseDTO
                {
                    StudentName = s.StudentName,
                    HostelName = s.Hostel.HostelName
                })
                .ToListAsync();
        }
    }
}