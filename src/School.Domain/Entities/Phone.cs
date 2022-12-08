namespace School.Domain.Entities
{
    public class Phone
    {
        public string GlobalCode { get; set; } = null!;
        public string LocalCode { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
