using Duende.IdentityModel.Client;

namespace Application.IRepositories.IAuthRepositories
{
    public interface IIdentityServerTokenService
    {
        Task<TokenResponse> GetTokenAsync(string username, string password);
    }
}
