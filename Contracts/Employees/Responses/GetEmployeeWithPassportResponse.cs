using Contracts.Passports.Responses;

namespace Contracts.Employees.Responses;

public class GetEmployeeWithPassportResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public int CompanyId { get; set; }
    public GetPassportResponse Passport { get; set; }
}