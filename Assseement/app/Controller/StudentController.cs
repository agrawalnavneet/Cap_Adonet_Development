// using app.DTOs;
// using Microsoft.AspNetCore.Mvc;
// using app.Services;
// [ApiController]
// [Route("api/[controller]")]
// public class StudentController : ControllerBase
// {
//     private readonly IStudentService _service;

//     public StudentController(IStudentService service)
//     {
//         _service = service;
//     }

//     [HttpPost]
//     public async Task<IActionResult> Create(StudentDTO dto)
//     {
//         await _service.AddStudent(dto);
//         return Ok();
//     }

//     [HttpPut("{id}")]
//     public async Task<IActionResult> Update(int id, StudentDTO dto)
//     {
//         await _service.UpdateStudent(id, dto);
//         return Ok();
//     }

//     [HttpDelete("{id}")]
//     public async Task<IActionResult> Delete(int id)
//     {
//         await _service.DeleteStudent(id);
//         return Ok();
//     }

//     [HttpGet("all")]
//     public async Task<IActionResult> GetStudents()
//     {
//         var data = await _service.GetAllStudents();
//         return Ok(data);
//     }

//     [HttpGet("hostel")]
//     public async Task<IActionResult> GetStudentsWithHostel()
//     {
//         var data = await _service.GetStudentsWithHostel();
//         return Ok(data);
//     }
// }


using app.DTOs;
using app.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentDTO dto)
    {
        await _service.CreateStudent(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateStudentDTO dto)
    {
        await _service.UpdateStudent(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteStudent(id);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var data = await _service.GetAllStudents();
        return Ok(data);
    }

    [HttpGet("hostel/{hostelName}")]
    public async Task<IActionResult> GetStudentsByHostel(string hostelName)
    {
        var data = await _service.GetStudentsByHostel(hostelName);
        return Ok(data);
    }
}