using Application.Dto.UserDtos;
using Application.IRepositories.IUserRepositories;
using Domain.UserAgg.UserEntity;
using Microsoft.AspNetCore.Identity;

namespace Application.Queries.AuthQueries.UserQuery.GetById
{
    public record UserGetByIdQuery(string Id) : IQuery<UserDto>;

    public class UserGetByIdQueryHandler : IQueryHandler<UserGetByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public UserGetByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _userRepository.UserManager.FindByIdAsync(request.Id);

                return user.Adapt<UserDto>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
