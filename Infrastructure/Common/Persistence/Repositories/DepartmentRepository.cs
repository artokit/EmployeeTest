using Domain.Common.Interfaces.Persistence;
using Domain.Postgres;
using Generic.Common.Interfaces;
using Generic.Dapper;
using Infrastructure.Common.Persistence.Scripts.Departments;
using Infrastructure.Common.Persistence.Scripts.Employees;

namespace Infrastructure.Common.Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDapperContext _dapperContext;

    public DepartmentRepository(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public ITransaction BeginTransaction()
    {
        return _dapperContext.BeginTransaction();
    }

    public async Task<DbDepartment> CreateAsync(DbDepartment department, ITransaction? transaction = null)
    {
        var queryObject = new QueryObject(PostgresDepartmentElement.CreateDepartment,
            new { name = department.Name, phone = department.Phone });

        return await _dapperContext.CommandWithResponse<DbDepartment>(queryObject, transaction);
    }

    public async Task<DbDepartment> UpdateAsync(DbDepartment department, ITransaction? transaction = null)
    {
        var queryObject = new QueryObject(PostgresDepartmentElement.UpdateDepartment,
            new { name = department.Name, phone = department.Phone, id = department.Id });
        
        return await _dapperContext.CommandWithResponse<DbDepartment>(queryObject, transaction);
    }

    public async Task<List<DbDepartment>> GetAllAsync()
    {
        var queryObject = new QueryObject(PostgresDepartmentElement.GetAllDepartments);
        return await _dapperContext.ListOrEmpty<DbDepartment>(queryObject);
    }

    public async Task<DbDepartment?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresDepartmentElement.GetDepartmentById, new { Id = id });
        return await _dapperContext.FirstOrDefault<DbDepartment>(queryObject);
    }

    public async Task DeleteAsync(int id, ITransaction? transaction = null)
    {
        var queryObject = new QueryObject(PostgresDepartmentElement.DeleteDepartment, new { id = id });
        await _dapperContext.Command(queryObject);
    }

    public async Task<DbDepartment?> GetByPhoneAsync(string phone)
    {
        var queryObject = new QueryObject(PostgresDepartmentElement.GetDepartmentByPhone, 
            new { phone = phone });
        
        return await _dapperContext.FirstOrDefault<DbDepartment>(queryObject);
    }

    public Task<List<DbEmployeePassport>> GetEmployeesAsync(int id)
    {
        var queryObject = new QueryObject(PostgresEmployeeElement.GetDepartmentEmployees, new { departmentId = id });
        
        return _dapperContext.ListOrEmpty<DbEmployeePassport>(queryObject);
    }
}