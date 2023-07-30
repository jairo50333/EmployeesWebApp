using EmployesWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployesWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpGet("GetEmployees")]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {

                return Ok(await this.employeeService.GetEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetEmployeeById/{idEmployee}")]
        public async Task<ActionResult> GetEmployeeById(int idEmployee)
        {
            try
            {
                return Ok(await this.employeeService.GetEmployeeById(idEmployee));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}