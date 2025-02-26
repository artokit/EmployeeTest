using Application.Exceptions.Abstractions;

namespace Application.Exceptions.Employees;

public class EmployeePhoneIsExist : BadRequestException
{
    public EmployeePhoneIsExist(string? message = "Сотрудник с данным номером телефона уже существует") : base(message) { }
}