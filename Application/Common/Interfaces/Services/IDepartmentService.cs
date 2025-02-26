using Contracts.Departments.Requests;
using Contracts.Departments.Responses;
using Contracts.Employees.Responses;

namespace Application.Common.Interfaces.Services;

public interface IDepartmentService
{
    public Task<GetDepartmentResponse> CreateAsync(CreateDepartmentRequest department);
    public Task<GetDepartmentResponse> UpdateAsync(UpdateDepartmentRequest department, int id);
    public Task<List<GetDepartmentResponse>> GetAllAsync();
    public Task<GetDepartmentResponse> GetByIdAsync(int id);
    public Task DeleteAsync(int id);
    public Task<List<GetEmployeeWithPassport>> GetEmployeesAsync(int id);
}
