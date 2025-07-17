using Application.IRepositories.IFormRepositories;
using Domain.FormAgg.FormTypeEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.FormRepositories
{
    public class FormTypeRepository : BaseRepository<FormType>, IFormTypeRepository
    {
        public FormTypeRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
