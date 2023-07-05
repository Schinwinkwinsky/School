namespace School.Domain.ValueObjects
{
    public class Phone
    {
        public string GlobalCode { get; set; } = default!;
        public string LocalCode { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        public string? Description { get; set; }
    }
}
