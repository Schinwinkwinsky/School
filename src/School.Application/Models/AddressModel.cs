using School.Domain.ValueObjects;

namespace School.Application.Models;

public class AddressModel
{
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string? Complement { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;

    public long Latitude { get; set; }
    public long Longitude { get; set; }

    public string? Description { get; set; }

    public static implicit operator Address(AddressModel model)
    {
        return new Address
        {
            Street = model.Street,
            Number = model.Number,
            District = model.District,
            City = model.City,
            State = model.State,
            Country = model.Country,
            PostCode = model.PostCode,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
            Description = model.Description
        };
    }
}
