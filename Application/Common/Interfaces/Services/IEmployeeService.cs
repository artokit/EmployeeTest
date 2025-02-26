using Contracts.Employees.Requests;
using Contracts.Employees.Responses;

namespace Application.Common.Interfaces.Services;

public interface IEmployeeService
{
    public Task<SuccessCreateEmployeeResponse> CreateAsync(CreateEmployeeRequest createEmployeeRequest);
    public Task DeleteAsync(int id);
    public Task<List<GetEmployeeResponse>> GetCompanyEmployeesAsync(int companyId);
    public Task<GetEmployeeResponse> UpdateAsync(UpdateEmployeeRequest updateEmployeeRequest, int id);
}