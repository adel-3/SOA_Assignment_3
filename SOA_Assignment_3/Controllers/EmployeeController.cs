using Microsoft.AspNetCore.Mvc;
using SOA_Assignment_3;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost("addEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return Ok(new { Message = "Employee added successfully." });
        }

        [HttpGet("searchById")]
        public IActionResult SearchEmployees([FromQuery] int? id)
        {
            var employees = _employeeService.SearchEmployeesById(id);
            return Ok(employees);
        }
        [HttpGet("searchByDesignation")]
        public IActionResult SearchEmployeesBydesignation([FromQuery] string designation)
        {
            var employees = _employeeService.SearchEmployeesByDesignation(designation);
            return Ok(employees);
        }

        [HttpDelete("deleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok(new { Message = "Employee deleted successfully." });
        }

        [HttpPut("updateEmployee/{id}")]
        public IActionResult UpdateDesignation(int id, [FromQuery] string newDesignation)
        {
            _employeeService.UpdateDesignation(id, newDesignation);
            return Ok(new { Message = "Employee designation updated successfully." });
        }

        [HttpGet("java-experts")]
        public IActionResult GetJavaExperts()
        {
            var javaExperts = _employeeService.GetJavaExperts();
            return Ok(javaExperts);
        }
    }
}
