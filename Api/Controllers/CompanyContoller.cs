using Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private IEmployeeService _employeeService;
    
    public CompanyController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{companyId}/employees")]
    public async Task<IActionResult> GetCompanyEmployees(int companyId)
    {
        return Ok(await _employeeService.GetCompanyEmployeesAsync(companyId));
    }
}