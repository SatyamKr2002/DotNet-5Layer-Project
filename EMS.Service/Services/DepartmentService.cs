using EMS.Model.DataModel;
using EMS.Model.Enum;
using EMS.Model.ViewModel;
using EMS.Model.ViewModel.DTOs;
using EMS.Repository.IRepositories;
using EMS.Service.IServices;
using Mapster;
using MapsterMapper;

namespace EMS.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentrepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentrepository, IMapper mapper)
        {
            _departmentrepository = departmentrepository;
            _mapper = mapper;
        }

        //1
        //public Department AddDepartment(DeptCreateDto deptCreateDto)
        //{
        //    var department = new Department()
        //    {
        //        DepartmentName = deptCreateDto.DepartmentName
        //    };
        //    repository.CreateDept(department);
        //    return department;
        //}

        //2
        //public DepartmentDto AddDepartment(DepartmentCreateDto departmentCreateDto)
        //{
        //    var department = new Department()
        //    {
        //        DepartmentName = departmentCreateDto.DepartmentName
        //    };
        //    _departmentrepository.CreateDept(department);

        //    return new DepartmentDto
        //    {
        //        DepartmentId = department.DepartmentId,
        //        DepartmentName = department.DepartmentName
        //    };
        //}

        public Response AddDepartment(DepartmentCreateDto departmentCreateDto)
        {
            try
            {
                //var department = departmentCreateDto.Adapt<Department>();
                var department = _mapper.Map<Department>(departmentCreateDto);  

                _departmentrepository.CreateDept(department);

                var departmentDto = _mapper.Map<DepartmentDto>(department);

                return new Response(201, MessageEnum.Created.ToString(), departmentDto);
            }
            catch (Exception ex)
            {
                return new Response(500, MessageEnum.ServerError.ToString(), ex.Message);
            }
        }

        //1
        //public IEnumerable<Department> GetAllDepartments()
        //{
        //    return repository.GetAllDepts();
        //}

        //2
        //public IEnumerable<DepartmentDto> GetAllDepartments()
        //{
        //    return _departmentrepository.GetAllDepts().Select(d => new DepartmentDto
        //    {
        //        DepartmentId = d.DepartmentId,
        //        DepartmentName = d.DepartmentName
        //    });
        //}

        public Response GetAllDepartments()
        {
            try
            {
                var departments = _departmentrepository.GetAllDepts();  

                var deptDto = _mapper.Map<List<DepartmentDto>>(departments);

                return new Response(200, MessageEnum.Success.ToString(), deptDto);
            }
            catch (Exception ex)
            {
                return new Response(500, MessageEnum.ServerError.ToString(), ex.Message);
            }
        }


        //public IEnumerable<DepartmentWithEmployeesDto> GetDepartmentsWithEmployees()
        //{
        //    var departments = _departmentrepository.GetAllDeptsWithEmployees();

        //    return departments.Select(d => new DepartmentWithEmployeesDto
        //    {
        //        DepartmentId = d.DepartmentId,
        //        DepartmentName = d.DepartmentName,
        //        Employees = d.Employees.Select(e => new EmployeeDto
        //        {
        //            EmployeeId = e.EmployeeId,
        //            Name = e.Name,
        //            Age = e.Age,
        //            DepartmentId = e.DepartmentId
        //        }).ToList()
        //    });
        //}
        public Response GetDepartmentsWithEmployees()
        {
            
            var departments = _departmentrepository.GetAllDeptsWithEmployees();

            var deptWithEmp = _mapper.Map<List<DepartmentWithEmployeesDto>>(departments);

            return  new Response(200,MessageEnum.Success.ToString(), deptWithEmp);
        }
    }
}
