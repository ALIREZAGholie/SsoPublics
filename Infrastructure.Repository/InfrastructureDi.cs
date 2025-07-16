using Application.IRepositories.IAuthRepositories;
using Infrastructure.Context;
using Infrastructure.Context.Contexts;
using Infrastructure.Repository.Repositories.AuthRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repository
{
    public static class InfrastructureDi
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureEf(configuration);
            services.AddScoped<EfContextInitializer>();

            #region Auth
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddHttpClient<IIdentityServerTokenService, IdentityServerTokenService>();
            #endregion

            return services;
        }
    }
}
