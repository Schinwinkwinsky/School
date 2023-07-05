namespace School.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; set; } = default!;

        public string? Description { get; set; }
    }
}
