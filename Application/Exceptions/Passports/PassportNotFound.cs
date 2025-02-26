using Application.Exceptions.Abstractions;

namespace Application.Exceptions.Passports;

public class PassportNotFound : NotFoundException
{
    public PassportNotFound(string? message = "У данного сотрудника нету удостоверения") : base(message) { }
}