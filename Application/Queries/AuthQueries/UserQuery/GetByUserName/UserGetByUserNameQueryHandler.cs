using Application.Dto.UserDtos;
using Application.IRepositories.IUserRepositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.AuthQueries.UserQuery.GetByUserName
{
    public record UserGetByUserNameQuery(string nationalCode) : IQuery<UserDto>;

    public class UserGetByUserNameQueryHandler : IQueryHandler<UserGetByUserNameQuery, UserDto>
    {
        private readonly IUserRepository _repository;

        public UserGetByUserNameQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> Handle(UserGetByUserNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _repository.Table()
                    .FirstOrDefaultAsync(x => x.UserName == request.nationalCode, 
                        cancellationToken: cancellationToken);

                return response.Adapt<UserDto>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
