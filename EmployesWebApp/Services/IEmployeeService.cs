using EmployesWebApp.Models;

namespace EmployesWebApp.Services
{
    public interface IEmployeeService
    {

        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int idEmployee);

    }
}
