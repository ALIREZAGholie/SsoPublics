using Domain._DomainException;
using Webgostar.Framework.Domain.ValueObjects;

namespace Domain._DomainValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is < 11 or > 11)
            {
                throw new InvalidDomainDataException("شماره تماس نامعتبر است");
            }
            Value = value;
        }

        public string Value { get; private set; }

        public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;
        public static implicit operator PhoneNumber(string phoneNumber) => new(phoneNumber);
    }
}
