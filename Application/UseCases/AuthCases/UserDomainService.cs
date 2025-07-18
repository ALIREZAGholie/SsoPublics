using Application.IRepositories.IUserRepositories;
using Domain.UserAgg.UserEntity.Services;

namespace Application.UseCases.AuthCases
{
    public class UserDomainService(IUserRepository userRepository) : IUserDomainService
    {
        public async Task<bool> IsExist(string nationalCode)
        {
            try
            {
                return await userRepository.ExistUser(nationalCode);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
