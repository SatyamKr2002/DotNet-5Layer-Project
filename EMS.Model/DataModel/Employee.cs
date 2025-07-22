using EMS.Model.BaseModel;

namespace EMS.Model.DataModel
{
    public class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}