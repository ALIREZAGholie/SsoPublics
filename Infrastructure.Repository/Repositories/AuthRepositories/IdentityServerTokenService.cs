using Application.IRepositories.IAuthRepositories;
using Duende.IdentityModel.Client;

namespace Infrastructure.Repository.Repositories.AuthRepositories
{
    public class IdentityServerTokenService(HttpClient httpClient) : IIdentityServerTokenService
    {
        public async Task<string> GetTokenAsync(string username, string password)
        {
            var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001"); // آدرس IdentityServer

            if (disco.IsError)
                throw new Exception(disco.Error);

            var tokenResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "postman-client",
                ClientSecret = "secret",
                UserName = username,
                Password = password,
                Scope = "api.read api.write"
            });

            if (tokenResponse.IsError)
                throw new Exception(tokenResponse.Error);

            return tokenResponse.AccessToken;
        }
    }
}
