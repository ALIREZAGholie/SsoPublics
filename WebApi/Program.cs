using Application.Queries._SystemErrorQueries.SystemErrorQuery;
using Application.UseCases._SystemErrorCases;
using Domain.RoleAgg.RoleEntity;
using Domain.UserAgg.UserEntity;
using Infrastructure.Context.Contexts;
using Infrastructure.Repository;
using Infrastructure.Repository.Repositories.ClientStoreServices;
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

builder.Services.AddIdentityServer(o =>
    {
        o.Events.RaiseErrorEvents = true;
        o.Events.RaiseInformationEvents = true;
        o.Events.RaiseFailureEvents = true;
        o.Events.RaiseSuccessEvents = true;

        o.EmitStaticAudienceClaim = true;
    })
    .AddDeveloperSigningCredential(persistKey: true)
    .AddProfileService<CustomProfileService>()
    .AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>()
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResource)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients);

var app = builder.Build();

app.UseIdentityServer();
app.UseFrameworkPresentationWeb();

app.Run();