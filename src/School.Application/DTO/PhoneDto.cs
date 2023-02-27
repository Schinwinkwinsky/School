namespace School.Application.DTO
{
    public class PhoneDto
    {
        public string GlobalCode { get; set; } = default!;
        public string LocalCode { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        public string? Description { get; set; }
    }
}
