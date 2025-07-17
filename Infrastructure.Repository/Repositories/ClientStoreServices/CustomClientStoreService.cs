using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using Infrastructure.Context.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories.ClientStoreServices
{
    public class CustomClientStoreService(EfContext context) : IClientStore
    {
        public async Task<Client?> FindClientByIdAsync(string clientId)
        {
            var entity = await context.Client.FirstOrDefaultAsync(c => c.ClientId == clientId);
            if (entity == null)
                return null;

            return new Client
            {
                ClientId = entity.ClientId,
                ClientName = entity.ClientName,
                AllowedGrantTypes = entity.AllowedGrantTypes.Split(',').ToList(),
                AllowedScopes = entity.AllowedScopes.Split(',').ToList(),
                ClientSecrets = new List<Secret> { new Secret(entity.ClientSecretHash.Sha256()) },
                AllowOfflineAccess = entity.AllowOfflineAccess,
                // بقیه کانفیگ‌ها
            };
        }
    }
}
