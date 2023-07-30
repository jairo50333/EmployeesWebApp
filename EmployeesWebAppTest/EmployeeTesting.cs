using EmployesWebApp.Controllers;
using EmployesWebApp.Models;
using EmployesWebApp.Repository;
using EmployesWebApp.Services;
using EmployesWebApp.Services.Implements;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesWebAppTest
{
    public class EmployeeTesting
    {

        private readonly EmployeeController _employeeController;
        private readonly IEmployeeService _employeeServices;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeTesting()
        {
            _employeeController = new EmployeeController(_employeeServices);
            _employeeServices = new EmployeeService(_employeeRepository);
        }


        [Fact]
        public void GetEmployees_OK()
        {
            var result = _employeeController.GetEmployees();
            Assert.IsType<Task<ActionResult>>(result);

        }

        [Fact]
        public void GetQuantityEmployees()
        {
            var result = _employeeController.GetEmployees();
            Assert.NotNull(result);
        }

        [Fact]
        public void GetEmployeesById_OK()
        {
            var result = _employeeController.GetEmployeeById(10);
            Assert.IsType<Task<ActionResult>>(result);

        }

        [Fact]
        public void GetEmployeesById()
        {
            var result = _employeeController.GetEmployeeById(10);
            Assert.NotNull(result);
        }
    }
}