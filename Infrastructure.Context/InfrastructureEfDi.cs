using Application;
using Infrastructure.Context.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webgostar.Framework.Infrastructure.Contexts;

namespace Infrastructure.Context
{
    public static class InfrastructureEfDi
    {
        public static IServiceCollection AddInfrastructureEf(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();

            services.AddDbContext<EfBaseContext, EfContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    o => o.CommandTimeout(120)));

            //services.AddDbContext<DbContext, EfBaseContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //        o => o.CommandTimeout(120)));

            //services.AddDbContext<EfContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //        o => o.CommandTimeout(120)));

            return services;
        }
    }
}