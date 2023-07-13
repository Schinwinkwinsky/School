using School.Domain.ValueObjects;

namespace School.Application.Models;

public class EmailModel
{
    public string Address { get; set; } = string.Empty;

    public string? Description { get; set; }

    public static implicit operator Email(EmailModel model)
    {
        return new Email
        {
            Address = model.Address,
            Description = model.Description
        };
    }
}
