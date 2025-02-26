using System.ComponentModel.DataAnnotations;

namespace Contracts.Departments.Requests;

public class UpdateDepartmentRequest
{
    [MinLength(1, ErrorMessage = "Название отдела не может быть пустым.")]
    public string? Name { get; set; }

    [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Телефон должен содержать от 10 до 15 цифр и может начинаться с '+'.")]
    public string? Phone { get; set; }
}