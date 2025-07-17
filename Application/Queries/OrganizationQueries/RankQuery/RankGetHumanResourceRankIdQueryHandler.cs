using Application.IRepositories.IOrganization;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.OrganizationQueries.RankQuery;

public record RankGetHumanResourceRankIdQuery() : IQuery<long>;

public class RankGetHumanResourceRankIdHandler : IQueryHandler<RankGetHumanResourceRankIdQuery, long>
{
    private readonly IRankRepository _repository;

    public RankGetHumanResourceRankIdHandler(IRankRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> Handle(RankGetHumanResourceRankIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var rank = await _repository.Table().FirstOrDefaultAsync(x => x.GKey == 32, cancellationToken: cancellationToken);

            return rank?.Id ?? 0;
        }
        catch (Exception)
        {
            throw;
        }
    }
}