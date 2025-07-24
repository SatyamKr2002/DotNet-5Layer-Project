using EMS.Model.ViewModel.DTOs;
using EMS.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeservice;

        public EmployeeController(IEmployeeService service)
        {
            _employeeservice = service;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var result = _employeeservice.GetAllEmployees();
            //return Ok(result);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            var result = _employeeservice.GetEmpById(id);
            //if (result == null)
            //{
            //    return NotFound();
            //}
            //return Ok(result);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("create")]

        public IActionResult CreateEmp(EmployeeCreateDto createDto)
        {
            var emp = _employeeservice.AddEmployee(createDto);
            //return Ok(emp);
            return StatusCode(emp.StatusCode, emp);
        }

        [HttpPost("delete")]
        public IActionResult DeleteEmp(int id)
        {
            var employee = _employeeservice.DeleteEmployee(id);
            return StatusCode(employee.StatusCode, employee);
        }
    }
}