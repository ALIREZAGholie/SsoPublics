namespace Domain.UserAgg.UserEntity.Services
{
    public interface IUserDomainService
    {
        Task<bool> IsExist(string nationalCode);
    }
}
