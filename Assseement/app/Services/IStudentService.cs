// using app.DTOs;


// namespace app.Services{
// public interface IStudentService
// {
//     Task AddStudent(StudentDTO dto);
//     Task UpdateStudent(int id, StudentDTO dto);
//     Task DeleteStudent(int id);
//     Task<List<StudentDTO>> GetAllStudents();
//     Task<List<StudentDTO>> GetStudentsWithHostel();
// }}


using app.DTOs;
namespace app.Services{
public interface IStudentService
{
    Task CreateStudent(CreateStudentDTO dto);
    Task UpdateStudent(int id, UpdateStudentDTO dto);
    Task DeleteStudent(int id);
    Task<List<StudentResponseDTO>> GetAllStudents();
    Task<List<StudentResponseDTO>> GetStudentsByHostel(string hostelName);
}}