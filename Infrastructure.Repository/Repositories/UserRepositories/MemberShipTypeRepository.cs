using Application.IRepositories.IUserRepositories;
using Domain.RoleAgg.MemberShipTypeEntity;
using Infrastructure.Context.Contexts;

namespace Infrastructure.Repository.Repositories.UserRepositories
{
    public class MemberShipTypeRepository : BaseRepository<MemberShipType>, IMemberShipTypeRepository
    {
        public MemberShipTypeRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }
    }
}
