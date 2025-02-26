using Domain.Postgres;
using Generic.Common.Interfaces;

namespace Domain.Common.Interfaces.Persistence;

public interface IDepartmentRepository
{
    public ITransaction BeginTransaction();
    public Task<DbDepartment> CreateAsync(DbDepartment department, ITransaction? transaction = null);
    public Task<DbDepartment> UpdateAsync(DbDepartment department, ITransaction? transaction = null);
    public Task<List<DbDepartment>> GetAllAsync();
    public Task<DbDepartment?> GetByIdAsync(int id);
    public Task DeleteAsync(int id, ITransaction? transaction = null);
    public Task<DbDepartment?> GetByPhoneAsync(string phone);
    public Task<List<DbEmployeePassport>> GetEmployeesAsync(int id);
}