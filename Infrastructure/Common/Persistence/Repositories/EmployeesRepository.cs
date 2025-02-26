using Domain.Common.Interfaces.Persistence;
using Domain.Postgres;
using Generic.Common.Interfaces;
using Generic.Dapper;
using Infrastructure.Common.Persistence.Scripts.Employees;

namespace Infrastructure.Common.Persistence.Repositories;

public class EmployeesRepository : IEmployeesRepository
{
    private IDapperContext _dapperContext;
    
    public EmployeesRepository(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public ITransaction BeginTransaction()
    {
        return _dapperContext.BeginTransaction();
    }
    
    public async Task<int> CreateAsync(DbEmployee employee, ITransaction? transaction = null)
    {
        var employeeQuery = new QueryObject(PostgresEmployeeElement.CreateEmployee, new
        {
            name = employee.Name,
            surname = employee.Surname,
            phone = employee.Phone,
            companyId = employee.CompanyId,
            departmentId = employee.DepartmentId
        });
            
        var employeeId = await _dapperContext.CommandWithResponse<int>(employeeQuery, transaction);
        return employeeId;

    }

    public async Task<List<DbEmployeeDetails>> GetEmployeesByCompanyIdAsync(int companyId)
    {
        var queryObject = new QueryObject(PostgresEmployeeElement.GetCompanyEmployees, new { companyId = companyId });
        var res = await _dapperContext.ListOrEmpty<DbEmployeeDetails>(queryObject);
        
        return res;
    }

    public async Task<DbEmployee> UpdateAsync(DbEmployee dbEmployee, ITransaction? transaction = null)
    {
        var queryObject = new QueryObject(PostgresEmployeeElement.UpdateEmployee, new
        {
            name=dbEmployee.Name,
            surname=dbEmployee.Surname,
            phone=dbEmployee.Phone,
            companyId=dbEmployee.CompanyId,
            departmentId=dbEmployee.DepartmentId,
            employeeId=dbEmployee.Id
        });
        
        return await _dapperContext.CommandWithResponse<DbEmployee>(queryObject, transaction);
    }

    public async Task DeleteAsync(int employeeId, ITransaction? transaction = null)
    {
        var queryObject = new QueryObject(PostgresEmployeeElement.DeleteEmployeeById, new
        {
            id = employeeId
        });
        
        await _dapperContext.Command(queryObject, transaction);
    }

    
    public async Task<DbEmployee?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresEmployeeElement.GetEmployeeById, new
        {
            id = id
        });

        return await _dapperContext.FirstOrDefault<DbEmployee>(queryObject);
    }

    public async Task<DbEmployee?> GetByPhoneAsync(string phone)
    {
        var queryObject = new QueryObject(PostgresEmployeeElement.GetEmployeeByPhone, new
        {
            phone = phone
        });

        return await _dapperContext.FirstOrDefault<DbEmployee>(queryObject);
    }
}