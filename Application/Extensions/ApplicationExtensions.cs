using Microsoft.Extensions.DependencyInjection;
using Application.Common.Interfaces.Services;
using Contracts.Departments.Responses;
using Contracts.Employees.Requests;
using Contracts.Employees.Responses;
using Contracts.Passports.Responses;
using Application.Services;
using Contracts.Departments.Requests;
using Contracts.Passports.Requests;
using Domain.Postgres;
using Mapster;

namespace Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        return services;
    }

    public static IServiceProvider ConfigureMapping(this IServiceProvider serviceProvider)
    {
        TypeAdapterConfig<CreateEmployeeRequest, DbEmployee>.NewConfig()
            .Map(dest => dest.Passport, src => src.Passport);

        TypeAdapterConfig<DbEmployeeDetails, GetEmployeeResponse>.NewConfig()
            .Map(dest => dest.Passport,
                src => new GetPassportResponse { Type = src.PassportType, Number = src.PassportNumber })
            .Map(dest => dest.Department,
                src => new GetEmployeeDepartmentResponse { Name = src.DepartmentName, Phone = src.DepartmentPhone });

        TypeAdapterConfig<DbEmployeePassport, GetEmployeeWithPassportResponse>.NewConfig()
            .Map(dest => dest.Passport,
                src => new GetPassportResponse { Type = src.PassportType, Number = src.PassportNumber });

        TypeAdapterConfig<UpdateEmployeeRequest, DbEmployee>
            .NewConfig()
            .IgnoreNullValues(true);
        
        TypeAdapterConfig<UpdatePassportRequest, DbPassport>
            .NewConfig()
            .IgnoreNullValues(true);
        
        TypeAdapterConfig<UpdateDepartmentRequest, DbDepartment>
            .NewConfig()
            .IgnoreNullValues(true);
        
        return serviceProvider;
    }
}