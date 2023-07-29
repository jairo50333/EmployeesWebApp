using EmployesWebApp.Models;

namespace EmployesWebApp.Repository
{
    public interface IEmployeeRepository 
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int idEmployee);

    }
}
