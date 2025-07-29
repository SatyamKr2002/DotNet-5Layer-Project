using EMS.Model.ViewModel.DTOs;
using EMS.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentservice;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentservice = departmentService;
        }


        [HttpGet]
        public IActionResult Get()
        { 
            var result = _departmentservice.GetAllDepartments();
            //return Ok(result);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("create")]
        public IActionResult CreateEmp([FromBody] DepartmentCreateDto dto)
        {
            var emp = _departmentservice.AddDepartment(dto);
            //return Ok(emp);
            return StatusCode(emp.StatusCode, emp);
        }

        [HttpGet("DepartmentWithEmployees")]
        public IActionResult GetDeptWithEmp()
        {
            var result = _departmentservice.GetDepartmentsWithEmployees();
            //return Ok(result);
            return StatusCode(result.StatusCode, result);
        }
    }
}
