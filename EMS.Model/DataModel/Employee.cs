using EMS.Model.BaseModel;
using System.ComponentModel.DataAnnotations;

namespace EMS.Model.DataModel
{
    public class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}