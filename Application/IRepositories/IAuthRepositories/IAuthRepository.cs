using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Identity.Data;

namespace Application.IRepositories.IAuthRepositories
{
    public interface IAuthRepository
    {
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<TokenResponse> LoginAsync(LoginRequest request);
    }
}
