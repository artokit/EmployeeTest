using Domain.Common.Interfaces.Persistence;
using Domain.Postgres;
using Generic.Common.Interfaces;
using Generic.Dapper;
using Infrastructure.Common.Persistence.Scripts.Passports;

namespace Infrastructure.Common.Persistence.Repositories;

public class PassportsRepository : IPassportsRepository
{
    private IDapperContext _dapperContext;
    
    public PassportsRepository(IDapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public ITransaction BeginTransaction()
    {
        return _dapperContext.BeginTransaction();
    }
    
    public async Task<int> CreateAsync(DbPassport dbPassport, ITransaction? transaction = null)
    {
        var passportQuery = new QueryObject(
            PostgresPassportElement.CreatePassport,
            new { type = dbPassport.Type, number = dbPassport.Number, employeeId = dbPassport.EmployeeId });

        return await _dapperContext.CommandWithResponse<int>(passportQuery, transaction);
    }

    public async Task<DbPassport> UpdateByEmployeeIdAsync(DbPassport dbPassport, ITransaction? transaction = null)
    {
        var queryObject = new QueryObject(PostgresPassportElement.UpdatePassport, new
        {
            type = dbPassport.Type,
            number = dbPassport.Number,
            employeeId = dbPassport.EmployeeId
        });
        
        return await _dapperContext.CommandWithResponse<DbPassport>(queryObject, transaction);
    }

    public async Task<DbPassport?> GetByEmployeeId(int employeeId)
    {
        var queryObject = new QueryObject(PostgresPassportElement.GetPassportByEmployeeId, new
        {
            employeeId=employeeId
        });
        
        return await _dapperContext.FirstOrDefault<DbPassport>(queryObject);
    }
}