namespace School.Domain.Entities
{
    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;

        public long Latitude { get; set; }
        public long Longitude { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
