using Application.Dto.OrganizationDtos.RankDtos;
using Application.IRepositories.IOrganization;
using Application.IRepositories.IRoleRepositories;
using Domain.RoleAgg.RoleEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.Queries.OrganizationQueries.RankQuery
{
    public record RankGetForEmployeWorkPlaceQuery(long RankId) : IQuery<RankGetForEmployeWorkPlaceDto>;

    public class RankGetForEmployeWorkPlaceHandler : IQueryHandler<RankGetForEmployeWorkPlaceQuery, RankGetForEmployeWorkPlaceDto>
    {
        private readonly IConfigOrganizationRankRepository _organizationRankRepository;
        private readonly IConfigOrganizationRepository _organizationRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthService _authService;

        public RankGetForEmployeWorkPlaceHandler(IConfigOrganizationRankRepository organizationRankRepository,
            IAuthService authService,
            IRoleRepository roleRepository, IConfigOrganizationRepository organizationRepository)
        {
            _organizationRankRepository = organizationRankRepository;
            _authService = authService;
            _roleRepository = roleRepository;
            _organizationRepository = organizationRepository;
        }

        public async Task<RankGetForEmployeWorkPlaceDto> Handle(RankGetForEmployeWorkPlaceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var roleId = _authService.GetRoleId();
                var role = await _roleRepository.GetByIdAsync(roleId, cancellationToken);
                var companyId = role.CompanyId;

                var model = await _organizationRankRepository.Table()
                    .Include(x => x.ConfigOrganization)
                    .Include(x => x.Rank)
                    .Where(x => x.RankId == request.RankId && x.ConfigOrganization.CompanyId == companyId)
                    .Select(x => new
                    {
                        x.RankId,
                        RankName = x.Rank.Name,
                        x.ConfigOrganization.PositionId,
                        PositionName = x.ConfigOrganization.Position.Name,
                        x.ConfigOrganizationId
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                var section = await _organizationRepository.GetSection(model.ConfigOrganizationId);

                return new RankGetForEmployeWorkPlaceDto()
                {
                    RankId = model.RankId,
                    PositionId = model.PositionId.Value,
                    PositionName = model.PositionName,
                    RankName = model.RankName,
                    SectionId = section.Id,
                    SectionName = section.Name
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
