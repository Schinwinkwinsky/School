namespace School.Domain.Entities
{
    public class Address
    {
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string District { get; set; } = null!;
        public string? Complement { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string PostCode { get; set; } = null!;

        public long Latitude { get; set; }
        public long Longitude { get; set; }

        public string? Description { get; set; }
    }
}
