using Application.Dto.UserDtos;
using Application.IRepositories.IUserRepositories;
using Domain.UserAgg.UserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.AuthQueries.UserQuery.GetByUserName
{
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
                User response = await _repository.UserManager.Users
                    .FirstOrDefaultAsync(x => x.UserName == request.nationalCode, cancellationToken: cancellationToken);

                return response.Adapt<UserDto>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
