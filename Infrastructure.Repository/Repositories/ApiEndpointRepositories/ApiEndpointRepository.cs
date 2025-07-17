using Application.IRepositories.IApiEndpointRepositories;
using Domain.ApiEndpointAgg.ApiEndpointEntity;
using Webgostar.Framework.Infrastructure.Contexts;

namespace Infrastructure.Repository.Repositories.ApiEndpointRepositories
{
    public class ApiEndpointRepository(EfBaseContext context, IRepositoryServices repositoryServices)
        : BaseRepository<ApiEndpoint>(context, repositoryServices), IApiEndpointRepository;
}
