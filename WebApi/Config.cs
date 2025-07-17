using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace WebApi
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api.read", "Read Access to API"),
                new ApiScope("api.write", "Write Access to API"),
            };

        public static IEnumerable<Client> Clients2 =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "postman-client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api.read", "api.write" },
                    AllowOfflineAccess = true
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "api1", IdentityServerConstants.StandardScopes.OfflineAccess },
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding
                }
            };
    }
}
