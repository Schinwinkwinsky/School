namespace School.Domain.Entities
{
    public class Phone
    {
        public string GlobalCode { get; set; } = string.Empty;
        public string LocalCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
