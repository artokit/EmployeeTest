using Generic.Common.Interfaces.Settings;
using Microsoft.Extensions.Configuration;

namespace Generic.Dapper.Settings;

public class DapperSettings : IDapperSettings
{
    public DapperSettings(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("Database");
    }

    public string ConnectionString { get; set; }
}