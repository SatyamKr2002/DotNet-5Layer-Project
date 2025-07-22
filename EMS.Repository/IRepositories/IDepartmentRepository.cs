using EMS.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository.IRepositories
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepts();
        //public Department GetById(int id);
        public Department CreateDept(Department department);
        IEnumerable<Department> GetAllDeptsWithEmployees();
    }
}
