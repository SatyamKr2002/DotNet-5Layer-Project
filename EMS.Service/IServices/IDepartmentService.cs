using EMS.Model.ViewModel;
using EMS.Model.ViewModel.DTOs;

namespace EMS.Service.IServices
{
    public interface IDepartmentService
    {
        Response GetAllDepartments();
        //Department GetDeptById(int id);
        Response AddDepartment(DepartmentCreateDto departmentCreateDto);
        public Response GetDepartmentsWithEmployees();
    }
}
