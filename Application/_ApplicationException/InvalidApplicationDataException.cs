using Webgostar.Framework.Application.ApplicationExceptions;

namespace Application._ApplicationException
{
    public class InvalidApplicationDataException(string message) : BaseApplicationException(message);
}
