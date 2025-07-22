using EMS.Model.BaseModel;

namespace EMS.Model.DataModel
{
    public class Department : BaseEntity
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
