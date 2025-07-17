namespace Application.IRepositories.IAuthRepositories
{
    public interface IIdentityServerTokenService
    {
        Task<string> GetTokenAsync(string username, string password);
    }
}
