using School.Domain.ValueObjects;

namespace School.Application.DTO
{
    public class AddressDto
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

        public static implicit operator Address(AddressDto dto)
        {
            return new Address
            {
                Street = dto.Street,
                Number = dto.Number,
                District = dto.District,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                PostCode = dto.PostCode,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Description = dto.Description
            };
        }
    }
}
