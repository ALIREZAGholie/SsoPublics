using Domain._DomainValueObjects;
using Domain.UserAgg.UserEntity;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.IRepositories.IUserRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> ExistUser(string username);
        Task<string> Login(PhoneNumber userName, string password);
        Task<string> RefreshToken(string token);
        Task<User?> ValidateCredentialsAsync(PhoneNumber userName, string password);
    }
}
