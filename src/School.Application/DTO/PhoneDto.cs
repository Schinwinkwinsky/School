using School.Domain.ValueObjects;

namespace School.Application.DTO
{
    public class PhoneDto
    {
        public string GlobalCode { get; set; } = default!;
        public string LocalCode { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        public string? Description { get; set; }

        public static implicit operator Phone(PhoneDto dto)
        {
            return new Phone
            {
                GlobalCode = dto.GlobalCode,
                LocalCode = dto.LocalCode,
                PhoneNumber = dto.PhoneNumber,
                Description = dto.Description
            };
        }
    }
}
