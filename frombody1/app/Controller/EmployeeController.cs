using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Services;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        // FromBody array of objects
        [HttpPost("add")]
        public IActionResult AddEmployees([FromBody] List<Employee> employees)
        {
            _service.AddEmployees(employees);
            return Ok("Employees added successfully");
        }

        // Get all employees
        [HttpGet("all")]
        public IActionResult GetAllEmployees()
        {
            var result = _service.GetAllEmployees();
            return Ok(result);
        }

        // Get total salary
        [HttpGet("totalsalary")]
        public IActionResult GetTotalSalary()
        {
            var total = _service.GetTotalSalary();
            return Ok(total);
        }
    }
}