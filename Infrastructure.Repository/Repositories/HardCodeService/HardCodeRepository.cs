using Application.IRepositories.IHardCode;
using Domain.HardCodeAgg.HardCodeEntity;
using Infrastructure.Context.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories.HardCodeService
{
    public class HardCodeRepository : BaseRepository<HardCode>, IHardCodeRepository
    {
        public HardCodeRepository(EfContext context, IRepositoryServices repositoryServices) : base(context, repositoryServices)
        {
        }

        public async Task<string> GetValueByKey(string Key)
        {
            try
            {
                HardCode? result = await base.Table()
                    .FirstOrDefaultAsync(x => x.Key == Key);

                return result?.Value;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
