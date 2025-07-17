using Application.IRepositories.IFormRepositories;
using Domain.FormAgg.FormEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.FormRepositories
{
    public class FormRepository : BaseRepository<Form>, IFormRepository
    {
        public FormRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
