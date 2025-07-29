using EMS.Common.HashPassword;
using EMS.Model.DataModel;
using EMS.Model.Enum;
using EMS.Model.ViewModel;
using EMS.Model.ViewModel.DTOs;
using EMS.Repository.IRepositories;
using EMS.Service.IServices;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EMS.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _login;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, 
            IPasswordHasher login, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _login = login;
            _logger = logger;
        }
        
        //1
        //public EmployeeDto AddEmployee(EmployeeCreateDto createDto)
        //{
        //    var employee = new Employee()
        //    {
        //        Name = createDto.Name,
        //        Age = createDto.Age,
        //        DepartmentId = createDto.DepartmentId,
        //        CreatedAt = DateTime.Now,
        //        CreatedBy = "System",
        //        IsDeleted = false
        //    };

        //    _employeeRepository.Create(employee);
           

        //    return new EmployeeDto
        //    {
        //        EmployeeId = employee.EmployeeId,
        //        Name = employee.Name,
        //        Age = employee.Age,
        //        DepartmentId = employee.DepartmentId
        //    };
        //}

        public Response AddEmployee(EmployeeCreateDto employeeCreateDto, string createdBy)
        {
            try
            {
                if (employeeCreateDto == null)
                    return new Response(400, MessageEnum.BadRequest.ToString(), "Employee data is required");

                var employee = _mapper.Map<Employee>(employeeCreateDto);
                employee.Password = _login.HashPassword(employee.Password);
                employee.CreatedAt = DateTime.UtcNow;
                employee.CreatedBy = createdBy;
                employee.IsDeleted = false;

                var createdEmployee = _employeeRepository.Create(employee);
                if (createdEmployee == null)
                    return new Response(500, MessageEnum.ServerError.ToString(), "Failed to create employee");

                var empDto = _mapper.Map<EmployeeDto>(employee);

                return new Response(201, MessageEnum.Created.ToString(), empDto);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error creating employee");
                return new Response(409, MessageEnum.Conflict.ToString(), "Database error occurred");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee");
                return new Response(500, MessageEnum.ServerError.ToString(), ex.Message);
            }
            //catch (Exception e)
            //{
            //    return new Response(500, MessageEnum.ServerError.ToString(), e.Message);
            //}

        }
        public Response GetAllEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetAll(includeDepartment: true);

                var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);

                return new Response(200, MessageEnum.Success.ToString(), employeeDtos);
            }
            catch (Exception e)
            {
                return new Response(500, MessageEnum.ServerError.ToString(), e.Message);
            }
        }

        //1
        //public IEnumerable<EmployeeDto> GetAllEmployees()
        //{
        //    var employees = _employeeRepository.GetAll(includeDepartment: true);

        //    return employees.Select(e => new EmployeeDto
        //    {
        //        EmployeeId = e.EmployeeId,
        //        Name = e.Name,
        //        Age = e.Age,
        //        DepartmentId = e.DepartmentId
        //    });
        //}

        public Response GetEmpById(int id)
        {
            try
            {
                var e = _employeeRepository.GetById(id);
                if (e == null)
                {
                    string msg = string.Join(" ", MessageEnum.Not_Found.ToString().Split('_'));
                    return new Response(404, msg);
                }

                var empDto = _mapper.Map<EmployeeDto>(e);
                return new Response(200, MessageEnum.Success.ToString(),empDto);
            }
            catch (Exception e)
            {
                return new Response(500, MessageEnum.ServerError.ToString(), e.Message);
            }
        }


        // 1. 
        //public EmployeeDto GetEmpById(int id)
        //{
        //   return employeeRepository.GetById(id);
        //}

        //2
        //public EmployeeDto GetEmpById(int id)
        //{
        //    var e = _employeeRepository.GetById(id);

        //    if (e == null) return null;

        //    return new EmployeeDto
        //    {
        //        EmployeeId = e.EmployeeId,
        //        Name = e.Name,
        //        Age = e.Age,
        //        DepartmentId = e.DepartmentId
        //    };
        //}
        public Response DeleteEmployee(int id)
        {
            try
            {
                var emp = _employeeRepository.GetById(id);
                if(emp == null)
                {
                    return new Response(404, MessageEnum.Not_Found.ToString());
                }
                emp.IsDeleted = true;
                emp.DeletedAt = DateTime.UtcNow;
                _employeeRepository.Update(emp);
                return new Response(200, MessageEnum.Success.ToString());
            }
            catch (Exception e)
            {
                return new Response(500, MessageEnum.ServerError.ToString(), e.Message);
            }
        }
    }
}
