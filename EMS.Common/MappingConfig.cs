using Mapster;
using EMS.Model.DataModel;
using EMS.Model.ViewModel.DTOs;

namespace EMS.Common
{
    public static class MappingConfig
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<Employee, EmployeeDto>.NewConfig();
            TypeAdapterConfig<EmployeeDto, Employee>.NewConfig();

            TypeAdapterConfig<EmployeeCreateDto, Employee>.NewConfig();

            TypeAdapterConfig<Department, DepartmentDto>.NewConfig();
            TypeAdapterConfig<DepartmentDto, Department>.NewConfig();
            //TypeAdapterConfig<Department, DepartmentDto>.NewConfig().TwoWays();

            TypeAdapterConfig<DepartmentCreateDto, Department>.NewConfig();

            TypeAdapterConfig<Department, DepartmentWithEmployeesDto>.NewConfig();
        }
    }
}
