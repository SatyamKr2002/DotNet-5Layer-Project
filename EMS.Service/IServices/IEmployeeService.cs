using EMS.Model.ViewModel;
using EMS.Model.ViewModel.DTOs;

namespace EMS.Service.IServices
{  
      public interface IEmployeeService
      {
        //IEnumerable<EmployeeDto> GetAllEmployees();
        Response GetAllEmployees();
        //EmployeeDto GetEmpById(int id);
        Response GetEmpById(int id);
        //EmployeeDto AddEmployee(EmployeeCreateDto createDto);
        Response AddEmployee(EmployeeCreateDto createDto);
    }
}
