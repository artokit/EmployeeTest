using System.Data;
using Dapper;
using Generic.Common.Interfaces;
using Generic.Common.Interfaces.Settings;
using Npgsql;

namespace Generic.Dapper;

public class DapperContext : IDapperContext
{
    private IDapperSettings _dapperSettings;

    public DapperContext(IDapperSettings dapperSettings)
    {
        _dapperSettings = dapperSettings;
    }

    public async Task<T?> FirstOrDefault<T>(IQueryObject queryObject)
    {
        return await Execute(query => query.QueryFirstOrDefaultAsync<T>(queryObject.Sql, queryObject.Parameters)).ConfigureAwait(false);
    }

    public async Task<List<T>> ListOrEmpty<T>(IQueryObject queryObject)
    {
        return (await Execute(query => query.QueryAsync<T>(queryObject.Sql, queryObject.Parameters)).ConfigureAwait(false)).AsList();
    }

    public async Task Command(IQueryObject queryObject, ITransaction? transaction = null)
    {
        await (transaction == null ? CommandExecute(queryObject) : transaction.Command(queryObject));
    }

    public async Task<T> CommandWithResponse<T>(IQueryObject queryObject, ITransaction? transaction = null)
    {
        return await (transaction == null ? CommandWithResponseExecute<T>(queryObject) : transaction.CommandWithResponse<T>(queryObject));
    }

    public ITransaction BeginTransaction()
    {
        return new Transaction(_dapperSettings.ConnectionString);
    }

    private async Task<T> Execute<T>(Func<IDbConnection, Task<T>> query)
    {
        using var connection = new NpgsqlConnection(_dapperSettings.ConnectionString);
        var result = await query(connection).ConfigureAwait(false);
        await connection.CloseAsync();
        
        return result;
    }
    
    private async Task CommandExecute(IQueryObject queryObject)
    {
        await Execute(query => query.ExecuteAsync(queryObject.Sql, queryObject.Parameters)).ConfigureAwait(false);
    }

    private async Task<T> CommandWithResponseExecute<T>(IQueryObject queryObject)
    {
        return await Execute(query => query.QueryFirstAsync<T>(queryObject.Sql, queryObject.Parameters)).ConfigureAwait(false);
    }
}