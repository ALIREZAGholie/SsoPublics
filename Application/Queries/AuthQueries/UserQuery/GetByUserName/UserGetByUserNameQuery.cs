using Application.Dto.UserDtos;
using Domain._DomainValueObjects;

namespace Application.Queries.AuthQueries.UserQuery.GetByUserName
{
    public record UserGetByUserNameQuery(string nationalCode) : IQuery<UserDto>;
}
