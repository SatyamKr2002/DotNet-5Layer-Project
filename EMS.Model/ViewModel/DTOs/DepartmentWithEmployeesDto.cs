using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model.ViewModel.DTOs
{
    public class DepartmentWithEmployeesDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }

}
