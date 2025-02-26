using Application.Exceptions.Abstractions;

namespace Application.Exceptions.Employees;

public class EmployeeNotFound : NotFoundException
{
    public EmployeeNotFound(string? message = "Данного сотрудника нет в системе") : base(message)
    {
    }
}