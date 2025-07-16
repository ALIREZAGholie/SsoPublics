using Microsoft.AspNetCore.Identity.Data;

namespace Application.IRepositories.IAuthRepositories
{
    public interface IAuthRepository
    {
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<string> LoginAsync(LoginRequest request);
    }
}
