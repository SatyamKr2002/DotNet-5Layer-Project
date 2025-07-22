using EMS.Model.ViewModel;

namespace EMS.Service.IServices
{  
      public interface IEmployeeService
      {
          IEnumerable<EmployeeDto> GetAllEmployees();
          EmployeeDto GetEmpById(int id);
          EmployeeDto AddEmployee(EmployeeCreateDto createDto);
      }
}
