using Duende.IdentityModel;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace WebApi
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        ];

        public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope("api", "All Access to API"),
            new ApiScope("api.read", "Read Access to API"),
            new ApiScope("api.write", "Write Access to API")
        ];

        public static IEnumerable<ApiResource> ApiResource =>
        [
            new ApiResource("testapi")
            {
                Scopes = ["api.read", "api.write"],
                ApiSecrets = [new Secret("SuperSecretPassword".Sha256())],
                UserClaims = ["role"]
            },
            new ApiResource("api/v1/Position/BindGrid")
            {
                Scopes = { "api" }
            }
        ];

        public static IEnumerable<Client> Clients =>
        [
            new Client
            {
                ClientId = "client",
                ClientName = "Client Password Client",

                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                ClientSecrets = { new Secret("SuperSecretPassword".Sha256()) },

                AllowedScopes = { "openid", "profile", "api" },
                RequireConsent = true
            },
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

                AllowedScopes = { "api.read", "api.write" },
                RequireConsent = true
            },
            new Client
            {
                ClientId = "client_id",

                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

                AllowedScopes = { "api", IdentityServerConstants.StandardScopes.OfflineAccess },
                AllowOfflineAccess = true,
                RefreshTokenUsage = TokenUsage.ReUse,
                RefreshTokenExpiration = TokenExpiration.Sliding
            },
            new Client
            {
                ClientId = "postman-client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

                AllowedScopes = { "api.read", "api.write" },
                AllowOfflineAccess = true
            },
            new Client
            {
                ClientId = "web",
                ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5002/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "verification",
                    "api"
                }
            }
        ];
    }
}
