using Webgostar.Framework.Infrastructure.InfrastructureExceptions;

namespace Infrastructure.Repository._InfrastructureException
{
    public class InvalidDataException(string message) : BaseInfrastructureException(message);
}
