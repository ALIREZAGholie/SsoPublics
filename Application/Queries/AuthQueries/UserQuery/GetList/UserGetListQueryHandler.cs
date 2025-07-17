using Application.Dto.UserDtos;
using Application.IRepositories.IUserRepositories;

namespace Application.Queries.AuthQueries.UserQuery.GetList
{
    public class UserGetListQueryHandler : IQueryHandler<UserGetListQuery, List<UserDto>>
    {
        private readonly IUserRepository _repository;

        public UserGetListQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDto>> Handle(UserGetListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = _repository.UserManager.Users.ToList();

                return users.Adapt<List<UserDto>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
