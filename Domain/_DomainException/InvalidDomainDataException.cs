using Webgostar.Framework.Domain.DomainExceptions;

namespace Domain._DomainException
{
    public class InvalidDomainDataException(string message) : BaseDomainException(message);
}
