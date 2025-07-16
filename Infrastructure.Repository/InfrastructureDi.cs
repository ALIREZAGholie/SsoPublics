using Application.IRepositories.IAuthRepositories;
using Application.IRepositories.ISystemErrorRepositories;
using Infrastructure.Context;
using Infrastructure.Context.Contexts;
using Infrastructure.Repository.Repositories.AuthRepositories;
using Infrastructure.Repository.Repositories.SystemErrorRepositories;
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

            #region SystemError
            services.AddScoped<ISystemErrorRepository, SystemErrorRepository>();
            #endregion

            #region Auth
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddHttpClient<IIdentityServerTokenService, IdentityServerTokenService>();
            #endregion

            return services;
        }
    }
}
