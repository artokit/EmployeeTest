using Domain.Postgres;
using Generic.Common.Interfaces;

namespace Domain.Common.Interfaces.Persistence;

public interface IEmployeesRepository
{
    public ITransaction BeginTransaction();
    public Task<DbEmployee> UpdateAsync(DbEmployee dbEmployee, ITransaction? transaction = null);
    public Task DeleteAsync(int id, ITransaction? transaction = null);
    public Task<DbEmployee?> GetByIdAsync(int id);
    public Task<DbEmployee?> GetByPhoneAsync(string phone);
    public Task<int> CreateAsync(DbEmployee employee, ITransaction? transaction = null);
    public Task<List<DbEmployeeDetails>> GetEmployeesByCompanyIdAsync(int companyId);
}