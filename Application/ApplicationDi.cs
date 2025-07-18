using Application.UseCases.AuthCases;
using Contracts;
using Domain.UserAgg.UserEntity.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationDi
    {
        /// <summary>
        /// Di Domain Services
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddContract();
            services.AddScoped<IUserDomainService, UserDomainService>();
            return services;
        }
    }
}
