using School.Domain.ValueObjects;

namespace School.Application.DTO;

public class PhoneDto
{
    public string GlobalCode { get; set; } = string.Empty;
    public string LocalCode { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;

    public string? Description { get; set; }

    public static implicit operator Phone(PhoneDto dto)
    {
        return new Phone
        {
            GlobalCode = dto.GlobalCode,
            LocalCode = dto.LocalCode,
            Number = dto.Number,
            Description = dto.Description
        };
    }
}
