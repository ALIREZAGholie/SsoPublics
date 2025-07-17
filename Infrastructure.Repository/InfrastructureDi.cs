using Application.IRepositories.IApiEndpointRepositories;
using Application.IRepositories.IAuthRepositories;
using Application.IRepositories.ICompanyRepositories;
using Application.IRepositories.IFormRepositories;
using Application.IRepositories.IHardCode;
using Application.IRepositories.ILocationRepositories;
using Application.IRepositories.IOrganization;
using Application.IRepositories.IRoleApiPermissionRepositories;
using Application.IRepositories.IRoleRepositories;
using Application.IRepositories.IUserRepositories;
using Infrastructure.Context;
using Infrastructure.Context.Contexts;
using Infrastructure.Repository.Repositories.ApiEndpointRepositories;
using Infrastructure.Repository.Repositories.AuthRepositories;
using Infrastructure.Repository.Repositories.AuthService;
using Infrastructure.Repository.Repositories.FormRepositories;
using Infrastructure.Repository.Repositories.HardCodeService;
using Infrastructure.Repository.Repositories.LocationRepositories;
using Infrastructure.Repository.Repositories.OrganizationService;
using Infrastructure.Repository.Repositories.RoleApiPermissionRepositories;
using Infrastructure.Repository.Repositories.RoleRepositories;
using Infrastructure.Repository.Repositories.UserRepositories;
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

            #region Organization
            services.AddScoped<IConfigOrganizationRepository, ConfigOrganizationRepository>();
            services.AddScoped<IConfigOrganizationRankRepository, ConfigOrganizationRankRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IRankRepository, RankRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            #endregion

            #region Auth
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormTypeRepository, FormTypeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationTypeRepository, LocationTypeRepository>();
            services.AddScoped<IMemberShipTypeRepository, MemberShipTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleFormRepository, RoleFormRepository>();
            #endregion

            #region HardCode
            services.AddScoped<IHardCodeRepository, HardCodeRepository>();
            #endregion

            return services;
        }
    }
}
