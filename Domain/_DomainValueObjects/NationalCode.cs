using Domain._DomainException;
using Webgostar.Framework.Domain.ValueObjects;

namespace Domain._DomainValueObjects
{
    public class NationalCode : ValueObject
    {
        public NationalCode(string valueCode)
        {
            if (valueCode.Length is < 10 or > 10 || !IranianNationalCodeChecker.IsValid(valueCode))
            {
                throw new InvalidDomainDataException("کدملی صحیح وارد کنید");
            }

            Value = valueCode;
        }

        public string Value { get; private set; }

        public static implicit operator string(NationalCode nationalCode) => nationalCode.Value;
        public static implicit operator NationalCode(string nationalCode) => new(nationalCode);
    }
}
