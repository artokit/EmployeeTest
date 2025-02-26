using Generic.Common.Interfaces;
using Generic.Common.Interfaces.Settings;
using Generic.Dapper;
using Generic.Dapper.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Generic.Extensions;

public static class GenericExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddSingleton<IDapperSettings, DapperSettings>();
        services.AddScoped<IDapperContext, DapperContext>();
        return services;
    }
}