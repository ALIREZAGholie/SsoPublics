using Domain.UserAgg.UserEntity;

namespace Application.IRepositories.IAuthRepositories
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(User user);
    }
}
