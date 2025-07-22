using EMS.Model.DataModel;
using EMS.Model.ViewModel;
using EMS.Repository.IRepositories;
using EMS.Service.IServices;

namespace EMS.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeDto AddEmployee(EmployeeCreateDto createDto)
        {
            var employee = new Employee()
            {
                Name = createDto.Name,
                Age = createDto.Age,
                DepartmentId = createDto.DepartmentId,
                CreatedAt = DateTime.Now,
                CreatedBy = "System",
                IsDeleted = false
            };

            _employeeRepository.Create(employee);

            return new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Age = employee.Age,
                DepartmentId = employee.DepartmentId
            };
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll(includeDepartment: true);

            return employees.Select(e => new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Age = e.Age,
                DepartmentId = e.DepartmentId
            });
        }
        //public EmployeeDto GetEmpById(int id)
        //{
        //   return employeeRepository.GetById(id);
        //}

        public EmployeeDto GetEmpById(int id)
        {
            var e = _employeeRepository.GetById(id);

            if (e == null) return null;

            return new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Age = e.Age,
                DepartmentId = e.DepartmentId
            };
        }


    }
}
