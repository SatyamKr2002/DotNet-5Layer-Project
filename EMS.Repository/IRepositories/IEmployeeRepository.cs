using EMS.Model.DataModel;

namespace EMS.Repository.IRepositories
{
    public interface IEmployeeRepository
    {
       public IEnumerable<Employee> GetAll(bool includeDepartment = false);
       public Employee GetById(int id);
       public Employee Create(Employee employee);
       public Employee GetByEmail(string email);
       public void Update(Employee employee);
    }
}
