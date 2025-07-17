using Domain.HardCodeAgg.HardCodeEntity;
using Webgostar.Framework.Base.IBaseServices;

namespace Application.IRepositories.IHardCode
{
    public interface IHardCodeRepository : IBaseRepository<HardCode>
    {
        Task<string> GetValueByKey(string Key);
    }
}
