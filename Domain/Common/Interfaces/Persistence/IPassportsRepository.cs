using Domain.Postgres;
using Generic.Common.Interfaces;

namespace Domain.Common.Interfaces.Persistence;

public interface IPassportsRepository
{
    public ITransaction BeginTransaction();
    public Task<int> CreateAsync(DbPassport dbPassport, ITransaction? transaction = null);
    public Task<DbPassport> UpdateByEmployeeIdAsync(DbPassport dbPassport, ITransaction? transaction = null);
    public Task<DbPassport?> GetByEmployeeId(int employeeId);
}