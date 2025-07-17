using Application.Queries._SystemErrorQueries.SystemErrorQuery;
using Application.UseCases._SystemErrorCases;
using Domain.RoleAgg.RoleEntity;
using Domain.UserAgg.UserEntity;
using Infrastructure.Context.CustomIdentity;
using Infrastructure.Repository;
using Infrastructure.Repository.Repositories.RoleRepositories;
using Infrastructure.Repository.Repositories.UserRepositories;
using Microsoft.AspNetCore.Identity;
using WebApi;
using Webgostar.Framework.Application;
using Webgostar.Framework.Infrastructure;
using Webgostar.Framework.Presentation.Web;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddFrameworkApplication()
    .AddFrameworkInfrastucture(builder.Configuration, typeof(SystemErrorAddCommand).Assembly, typeof(SystemErrorGetListQuery).Assembly)
    .AddFrameworkPresentationWeb(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

services.AddIdentity<User, Role>(options =>
    {

    })
    .AddUserStore<CustomUserStore>()
    .AddRoleStore<CustomRoleStore>()
    //.AddUserManager<UserRepository>()
    //.AddRoleManager<RoleRepository>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<User>()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
    //.AddInMemoryApiResources(Config.ApiResources)
    //.AddInMemoryIdentityResources(Config.IdentityResources)
    .AddDeveloperSigningCredential();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseIdentityServer();
app.UseFrameworkPresentationWeb();

app.Run();