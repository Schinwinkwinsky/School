using School.Domain.ValueObjects;

namespace School.Application.Models
{
    public class PhoneModel
    {
        public string GlobalCode { get; set; } = default!;
        public string LocalCode { get; set; } = default!;
        public string Number { get; set; } = default!;

        public string? Description { get; set; }

        public static implicit operator Phone(PhoneModel model)
        {
            return new Phone
            {
                GlobalCode = model.GlobalCode,
                LocalCode = model.LocalCode,
                Number = model.Number,
                Description = model.Description
            };
        }
    }
}
