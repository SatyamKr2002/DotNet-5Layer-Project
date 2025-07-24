using EMS.Common.HashPassword;
using EMS.Model.DataModel;
using EMS.Model.Enum;
using EMS.Model.ViewModel;
using EMS.Model.ViewModel.DTOs;
using EMS.Repository.IRepositories;
using EMS.Service.IServices;
using MapsterMapper;

namespace EMS.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _login;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IPasswordHasher login)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _login = login;
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

        public Response AddEmployee(EmployeeCreateDto employeeCreateDto)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeCreateDto);
                employee.Password = _login.HashPassword(employee.Password);
                employee.CreatedAt = DateTime.Now;
                employee.CreatedBy = "System";
                employee.IsDeleted = false;

                _employeeRepository.Create(employee);

                var empDto = _mapper.Map<EmployeeDto>(employee);

                return new Response(201, MessageEnum.Created.ToString(), empDto);
            }
            catch (Exception e)
            {
                return new Response(500, MessageEnum.ServerError.ToString(), e.Message);
            }

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
