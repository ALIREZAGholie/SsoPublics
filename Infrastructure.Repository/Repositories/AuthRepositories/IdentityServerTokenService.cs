using Application._ApplicationException;
using Application.IRepositories.IAuthRepositories;
using Duende.IdentityModel.Client;
using Duende.IdentityServer.Models;

namespace Infrastructure.Repository.Repositories.AuthRepositories
{
    public class IdentityServerTokenService(HttpClient httpClient) : IIdentityServerTokenService
    {
        public async Task<string> GetTokenAsync(string username, string password)
        {
            var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:44330"); // آدرس IdentityServer

            if (disco.IsError)
                throw new Exception(disco.Error);

            var tokenRequest = new PasswordTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "SuperSecretPassword",
                UserName = username,
                Password = password,
                Scope = "profile",
                GrantType = GrantType.ResourceOwnerPassword
            };

            var tokenResponse = await httpClient.RequestPasswordTokenAsync(tokenRequest);

            if (tokenResponse.IsError)
                throw new AuthException(tokenResponse.Raw);

            return tokenResponse.AccessToken;
        }
    }
}
