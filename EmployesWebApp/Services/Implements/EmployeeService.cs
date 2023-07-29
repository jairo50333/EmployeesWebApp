using EmployesWebApp.Models;
using EmployesWebApp.Repository;

namespace EmployesWebApp.Services.Implements
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await this.employeeRepository.GetEmployees();
        }

        public async Task<Employee> GetEmployeeById(int idEmployee)
        {
            return await this.employeeRepository.GetEmployeeById(idEmployee);
        }

    }
}
