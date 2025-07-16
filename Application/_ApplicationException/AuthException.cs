using Webgostar.Framework.Application.ApplicationExceptions;

namespace Application._ApplicationException
{
    public class AuthException(string message) : BaseApplicationException(message);
}
