using EMS.Model.DataModel;
using EMS.Repository.Context;
using EMS.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.Repository.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EMSDbContext _context;

        public DepartmentRepository(EMSDbContext context)
        {
            _context = context;
        }
        public Department CreateDept(Department department)
        {
            _context.Department.Add(department);
            _context.SaveChanges();
            return department;
        }

        public IEnumerable<Department> GetAllDepts()
        {
            return _context.Department.ToList();
        }

        public IEnumerable<Department> GetAllDeptsWithEmployees()
        {
            return _context.Department
                .Include(d => d.Employees)
                .ToList();
        }

    }
}
