using Application.Dto.UserDtos;
using Application.IRepositories.IUserRepositories;

namespace Application.Queries.AuthQueries.UserQuery.GetById
{
    public record UserGetByIdQuery(long Id) : IQuery<UserDto>;

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
                var user = await _userRepository.GetByIdAsync(request.Id,cancellationToken);

                return user.Adapt<UserDto>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
