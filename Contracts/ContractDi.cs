using Microsoft.Extensions.DependencyInjection;

namespace Contracts
{
    public static class ContractDi
    {
        public static IServiceCollection AddContract(this IServiceCollection services)
        {

            return services;
        }
    }
}
