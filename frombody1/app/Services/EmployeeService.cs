using app.Models;

namespace app.Services
{
    public class EmployeeService
    {
        private static List<Employee> employees = new List<Employee>();

        public void AddEmployees(List<Employee> empList)
        {
            employees.AddRange(empList);
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public decimal GetTotalSalary()
        {
            return employees.Sum(e => e.Salary);
        }
    }
}