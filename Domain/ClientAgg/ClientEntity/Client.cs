namespace Domain.ClientAgg.ClientEntity
{
    public class Client : BaseEntity
    {
        public string ClientId { get; private set; }
        public string ClientName { get; private set; }
        public string ClientSecretHash { get; private set; }
        public string AllowedGrantTypes { get; private set; }
        public string AllowedScopes { get; private set; }
        public bool AllowOfflineAccess { get; private set; }
    }
}
