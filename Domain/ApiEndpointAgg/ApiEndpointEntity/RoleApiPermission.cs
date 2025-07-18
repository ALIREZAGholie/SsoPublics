using Domain.RoleAgg.RoleEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ApiEndpointAgg.ApiEndpointEntity
{
    public class RoleApiPermission : BaseEntity
    {
        public RoleApiPermission()
        {

        }

        public long RoleId { get; private set; }
        public long ApiEndpointId { get; private set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        [ForeignKey(nameof(ApiEndpointId))]
        public ApiEndpoint ApiEndpoint { get; set; }


        public RoleApiPermission(long roleId, long apiEndpointId)
        {
            RoleId = roleId;
            ApiEndpointId = apiEndpointId;
        }
    }
}
