using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBenchmark.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;

        public EmployeeController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var owners = await _serviceManager.EmployeeService.GetAllEmployeesAsync();

            return Ok(owners);
        }

        [HttpGet("{employeeId:guid}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            var employee = await _serviceManager.EmployeeService.GetEmployeeByIdAsync(employeeId);

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForCreationDto employeeForCreation )
        {
            var employee = await _serviceManager.EmployeeService.CreateEmployeeAsync(employeeForCreation);

            return CreatedAtAction(nameof(GetEmployeeById), new { employeeId = employee.Id }, employee);
        }

        [HttpPut("{employeeId:guid}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeForUpdateDto employeeForUpdate)
        {
            await _serviceManager.EmployeeService.UpdateEmployeeAsync(employeeId, employeeForUpdate);

            return NoContent();
        }

        [HttpDelete("{employeeId:guid}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            await _serviceManager.EmployeeService.DeleteEmployeeAsync(employeeId);

            return NoContent();
        }
    }
}
