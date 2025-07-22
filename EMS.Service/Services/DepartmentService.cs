using EMS.Model.DataModel;
using EMS.Model.ViewModel;
using EMS.Repository.IRepositories;
using EMS.Repository.Repositories;
using EMS.Service.IServices;

namespace EMS.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentrepository;

        public DepartmentService(IDepartmentRepository departmentrepository)
        {
            _departmentrepository = departmentrepository;
        }
        //public Department AddDepartment(DeptCreateDto deptCreateDto)
        //{
        //    var department = new Department()
        //    {
        //        DepartmentName = deptCreateDto.DepartmentName
        //    };
        //    repository.CreateDept(department);
        //    return department;
        //}
        public DepartmentDto AddDepartment(DepartmentCreateDto departmentCreateDto)
        {
            var department = new Department()
            {
                DepartmentName = departmentCreateDto.DepartmentName
            };
            _departmentrepository.CreateDept(department);

            return new DepartmentDto
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
        }
        //public IEnumerable<Department> GetAllDepartments()
        //{
        //    return repository.GetAllDepts();
        //}
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            return _departmentrepository.GetAllDepts().Select(d => new DepartmentDto
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName
            });
        }

        public IEnumerable<DepartmentWithEmployeesDto> GetDepartmentsWithEmployees()
        {
            var departments = _departmentrepository.GetAllDeptsWithEmployees();

            return departments.Select(d => new DepartmentWithEmployeesDto
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                Employees = d.Employees.Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    Age = e.Age,
                    DepartmentId = e.DepartmentId
                }).ToList()
            });
        }

    }
}
