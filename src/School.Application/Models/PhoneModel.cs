using School.Domain.Entities;

namespace School.Application.Models
{
    public class PhoneModel
    {
        public string GlobalCode { get; set; } = default!;
        public string LocalCode { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        public string? Description { get; set; }

        public static implicit operator Phone(PhoneModel model)
        {
            return new Phone
            {
                GlobalCode = model.GlobalCode,
                LocalCode = model.LocalCode,
                PhoneNumber = model.PhoneNumber,
                Description = model.Description
            };
        }
    }
}
