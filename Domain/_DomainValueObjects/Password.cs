using Domain._DomainException;
using Webgostar.Framework.Domain.ValueObjects;
using Webgostar.Framework.Domain.ValueObjects.Auth;

namespace Domain._DomainValueObjects
{
    public class Password : ValueObject
    {
        public Password(string value, AuthPasswordOptions options)
        {
            bool passCheck = new PasswordChecker().Validate(value, options ?? new AuthPasswordOptions());

            if (passCheck)
            {
                Value = value;
            }
            else
            {
                throw new InvalidDomainDataException(passCheck.ToString());
            }
        }

        public string Value { get; private set; }

        public static implicit operator string(Password password) => password.Value;
        //public static implicit operator Password(string password, IOptions<AuthPasswordOptions> options) => new(password,options);
    }
}
