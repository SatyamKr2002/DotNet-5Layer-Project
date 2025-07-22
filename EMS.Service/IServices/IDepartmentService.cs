using EMS.Model.ViewModel;

namespace EMS.Service.IServices
{
    public interface IDepartmentService
    {
        IEnumerable<DeptDto> GetAllDepartments();
        //Department GetDeptById(int id);
        DeptDto AddDepartment(DeptCreateDto deptCreateDto);
        public IEnumerable<DepartmentWithEmployeesDto> GetDepartmentsWithEmployees();
    }
}
