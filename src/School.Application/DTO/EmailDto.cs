using School.Domain.ValueObjects;

namespace School.Application.DTO
{
    public class EmailDto
    {
        public string Address { get; set; } = default!;

        public string? Description { get; set; }

        public static implicit operator Email(EmailDto dto)
        {
            return new Email
            {
                Address = dto.Address,
                Description = dto.Description
            };
        }
    }
}
