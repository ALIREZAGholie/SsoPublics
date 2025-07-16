using Application.IRepositories.ISystemErrorRepositories;
using Infrastructure.Context.Contexts;
using Webgostar.Framework.Base.BaseModels;
using Webgostar.Framework.Infrastructure.BaseServices;
using Webgostar.Framework.Infrastructure.BaseServices.IDIContainer;

namespace Infrastructure.Repository.Repositories.SystemErrorRepositories
{
    public class SystemErrorRepository(EfContext context, IRepositoryServices repositoryServices)
        : BaseRepository<SystemError>(context, repositoryServices), ISystemErrorRepository;
}
