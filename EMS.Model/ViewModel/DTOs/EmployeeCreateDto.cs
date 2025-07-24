using EMS.Model.BaseModel;
using System.ComponentModel.DataAnnotations;

namespace EMS.Model.ViewModel.DTOs
{
    public class EmployeeCreateDto
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
