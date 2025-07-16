using Application.Queries._SystemErrorQueries.SystemErrorQuery;
using Application.UseCases._SystemErrorCases;
using Domain.RoleAgg.RoleEntity;
using Domain.UserAgg.UserEntity;
using Infrastructure.Context.Contexts;
using Infrastructure.Repository;
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

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<EfContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<User>()
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddDeveloperSigningCredential();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseIdentityServer();
app.UseFrameworkPresentationWeb();

app.Run();