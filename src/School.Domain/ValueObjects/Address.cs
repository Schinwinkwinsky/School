namespace School.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string District { get; set; } = default!;
        public string? Complement { get; set; }
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string PostCode { get; set; } = default!;

        public long Latitude { get; set; }
        public long Longitude { get; set; }

        public string? Description { get; set; }
    }
}
