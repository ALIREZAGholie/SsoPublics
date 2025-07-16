using Application.IRepositories.IApiEndpointRepositories;
using Application.IRepositories.IAuthRepositories;
using Application.IRepositories.IRoleApiPermissionRepositories;
using Infrastructure.Context;
using Infrastructure.Context.Contexts;
using Infrastructure.Repository.Repositories.ApiEndpointRepositories;
using Infrastructure.Repository.Repositories.AuthRepositories;
using Infrastructure.Repository.Repositories.RoleApiPermissionRepositories;
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
            services.AddScoped<ITokenService, TokenService>();
            services.AddHttpClient<IIdentityServerTokenService, IdentityServerTokenService>();
            #endregion

            #region ApiEndpoint
            services.AddHttpClient<IApiEndpointRepository, ApiEndpointRepository>();
            #endregion

            #region RoleApiPermission
            services.AddHttpClient<IRoleApiPermissionRepository, RoleApiPermissionRepository>();
            #endregion

            return services;
        }
    }
}
