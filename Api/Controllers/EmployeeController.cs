using Application.Common.Interfaces.Services;
using Contracts.Employees.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private IEmployeeService _employeeService;
    
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(CreateEmployeeRequest createEmployeeRequest)
    {
        return Ok(await _employeeService.CreateAsync(createEmployeeRequest));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _employeeService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeRequest updateEmployeeRequest)
    {
        return Ok(await _employeeService.UpdateAsync(updateEmployeeRequest, id));
    }
}