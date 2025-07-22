using EMS.Model.DataModel;
using EMS.Repository.Context;
using EMS.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EMSDbContext _context;
        
        public EmployeeRepository(EMSDbContext context)
        {
            _context = context;
        }

        public Employee Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        //public IEnumerable<Employee> GetAll()
        //{
        //    return _context.Employees.ToList();
        //}
        public IEnumerable<Employee> GetAll(bool includeDepartment = false)
        {
            if (includeDepartment)
                return _context.Employees.Include(e => e.Department).ToList();

            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees
                           .Include(e => e.Department)
                           .FirstOrDefault(e => e.EmployeeId == id);
        }

    }
}
