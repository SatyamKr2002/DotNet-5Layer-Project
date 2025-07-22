using EMS.Model.ViewModel;
using EMS.Service.IServices;
using EMS.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentservice;
        public DepartmentController(IDepartmentService service)
        {
            this._departmentservice = service;
        }

        [HttpGet]
        public IActionResult Get()
        { 
            var result = _departmentservice.GetAllDepartments();
            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult CreateEmp(DeptCreateDto dto)
        {
            var emp = _departmentservice.AddDepartment(dto);
            return Ok(emp);
        }

        [HttpGet("WithEmployees")]
        public IActionResult GetDeptWithEmp()
        {
            var result = _departmentservice.GetDepartmentsWithEmployees();
            return Ok(result);
        }
    }
}
