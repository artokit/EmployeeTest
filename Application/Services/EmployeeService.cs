using Application.Common.Interfaces.Services;
using Application.Exceptions.Departments;
using Application.Exceptions.Employees;
using Application.Exceptions.Passports;
using Contracts.Departments.Responses;
using Contracts.Employees.Requests;
using Contracts.Employees.Responses;
using Contracts.Passports.Responses;
using Domain.Common.Interfaces.Persistence;
using Domain.Postgres;
using Mapster;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    private IEmployeesRepository _employeesRepository;
    private IPassportsRepository _passportsRepository;
    private IDepartmentRepository _departmentRepository;
    
    public EmployeeService(IEmployeesRepository employeesRepository, IPassportsRepository passportsRepository, IDepartmentRepository departmentRepository)
    {
        _employeesRepository = employeesRepository;
        _passportsRepository = passportsRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<SuccessCreateEmployeeResponse> CreateAsync(CreateEmployeeRequest createEmployeeRequest)
    {
        var employee = await _employeesRepository.GetByPhoneAsync(createEmployeeRequest.Phone);
        
        if (await _departmentRepository.GetByIdAsync(createEmployeeRequest.DepartmentId) is null)
        {
            throw new DepartmentNotFound();
        }
        
        if (employee is not null)
        {
            throw new EmployeePhoneIsExist();
        }
        
        var transaction = _employeesRepository.BeginTransaction();
        
        try
        {
            var employeeCandidate = createEmployeeRequest.Adapt<DbEmployee>();
            var employeeId = await _employeesRepository.CreateAsync(employeeCandidate, transaction);
            
            var passportCandidate = createEmployeeRequest.Passport.Adapt<DbPassport>();
            passportCandidate.EmployeeId = employeeId;
            
            await _passportsRepository.CreateAsync(passportCandidate, transaction);

            transaction.Commit();
            return new SuccessCreateEmployeeResponse { Id = employeeId };
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _employeesRepository.GetByIdAsync(id);
        if (employee is null)
        {
            throw new EmployeeNotFound();
        }
        
        await _employeesRepository.DeleteAsync(id);
    }
    
    public async Task<List<GetEmployeeResponse>> GetCompanyEmployeesAsync(int companyId)
    {
        var res = await _employeesRepository.GetEmployeesByCompanyIdAsync(companyId);
        
        return res.Select(e => e.Adapt<GetEmployeeResponse>()).ToList();
    }

    public async Task<GetEmployeeResponse> UpdateAsync(UpdateEmployeeRequest updateEmployeeRequest, int id)
    {
        var dbEmployee = await _employeesRepository.GetByIdAsync(id);
        var dbPassport = await _passportsRepository.GetByEmployeeId(id);

        if (updateEmployeeRequest.Phone is not null && await _employeesRepository.GetByPhoneAsync(updateEmployeeRequest.Phone) is not null)
        {
            throw new EmployeePhoneIsExist();
        }
        
        if (dbEmployee is null)
        {
            throw new EmployeeNotFound();
        }

        if (dbPassport is null)
        {
            throw new PassportNotFound();
        }
        
        var dbDepartment = await _departmentRepository.GetByIdAsync(updateEmployeeRequest.DepartmentId ?? dbEmployee.DepartmentId);
        
        if (dbDepartment is null)
        {
            throw new DepartmentNotFound();
        }
        
        var updatedEmployee = updateEmployeeRequest.Adapt(dbEmployee);

        var updatedPassport = updateEmployeeRequest.Passport?.Adapt(dbPassport) ?? dbPassport;

        var transaction = _employeesRepository.BeginTransaction();
        try
        {
            var updatedDbEmployee = await _employeesRepository.UpdateAsync(updatedEmployee,
                transaction);
            var updatedDbPassport = await _passportsRepository.UpdateByEmployeeIdAsync(updatedPassport);
            
            transaction.Commit();

            var res = updatedDbEmployee.Adapt<GetEmployeeResponse>();
            res.Passport = updatedDbPassport.Adapt<GetPassportResponse>();
            res.Department = dbDepartment.Adapt<GetDepartmentResponse>();
            return res;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}