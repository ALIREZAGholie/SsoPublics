using Domain.UserAgg.UserEntity;
using Microsoft.AspNetCore.Identity;

namespace Application.IRepositories.IUserRepositories
{
    public interface IUserRepository 
    {
        Task<bool> ExistUser(string username);
        UserManager<User> UserManager { get; set; }
    }
}
