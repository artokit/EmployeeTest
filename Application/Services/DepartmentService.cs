using Application.Common.Interfaces.Services;
using Application.Exceptions.Departments;
using Contracts.Departments.Requests;
using Contracts.Departments.Responses;
using Contracts.Employees.Responses;
using Domain.Common.Interfaces.Persistence;
using Domain.Postgres;
using Mapster;

namespace Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<GetDepartmentResponse> CreateAsync(CreateDepartmentRequest department)
    {
        if (await _departmentRepository.GetByPhoneAsync(department.Phone) is not null)
        {
            throw new DepartmentPhoneIsExist();
        }
        
        return (await _departmentRepository.CreateAsync(department.Adapt<DbDepartment>())).Adapt<GetDepartmentResponse>();
    }

    public async Task<GetDepartmentResponse> UpdateAsync(UpdateDepartmentRequest department, int id)
    {
        var candidate = await _departmentRepository.GetByIdAsync(id);
        if (candidate is null)
        {
            throw new DepartmentNotFound();
        }
        
        return (await _departmentRepository.UpdateAsync(department.Adapt(candidate))).Adapt<GetDepartmentResponse>();
    }

    public async Task<List<GetDepartmentResponse>> GetAllAsync()
    {
        var res = await _departmentRepository.GetAllAsync();

        return res.Select(d => d.Adapt<GetDepartmentResponse>()).ToList();
    }

    public async Task<GetDepartmentResponse> GetByIdAsync(int id)
    {
        var res = await _departmentRepository.GetByIdAsync(id);
        if (res is null)
        {
            throw new DepartmentNotFound();
        }

        return res.Adapt<GetDepartmentResponse>();
    }

    public async Task DeleteAsync(int id)
    {
        var res = await _departmentRepository.GetByIdAsync(id);
        if (res is null)
        {
            throw new DepartmentNotFound();
        }
        
        await _departmentRepository.DeleteAsync(id);
    }

    public async Task<List<GetEmployeeWithPassport>> GetEmployeesAsync(int id)
    {
        if (await _departmentRepository.GetByIdAsync(id) is null)
        {
            throw new DepartmentNotFound();
        }
        
        var res = await _departmentRepository.GetEmployeesAsync(id);
        return res.Select(e => e.Adapt<GetEmployeeWithPassport>()).ToList();
    }
}