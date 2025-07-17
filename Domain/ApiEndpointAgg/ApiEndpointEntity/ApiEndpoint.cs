using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ApiEndpointAgg.ApiEndpointEntity
{
    public class ApiEndpoint : BaseEntity
    {
        public ApiEndpoint()
        {

        }

        public string ApiEndpointTypeId { get; private set; }
        public string Route { get; private set; }
        public string DisplayName { get; private set; }
        public bool IsActive { get; private set; }

        [ForeignKey(nameof(ApiEndpointTypeId))]
        public ApiEndpointType ApiEndpointType { get; set; }
        public ICollection<RoleApiPermission> RolePermissions { get; set; }


        public ApiEndpoint(string apiEndpointTypeId, string route, string displayName)
        {
            ApiEndpointTypeId = apiEndpointTypeId;
            Route = route;
            DisplayName = displayName;
            IsActive = true;
        }

        public ApiEndpoint Edit(string apiEndpointTypeId, string route, string displayName)
        {
            ApiEndpointTypeId = apiEndpointTypeId;
            Route = route;
            DisplayName = displayName;

            return this;
        }

        public ApiEndpoint SetDeActive()
        {
            IsActive = false;
            return this;
        }

        public ApiEndpoint SetActive()
        {
            IsActive = true;
            return this;
        }
    }
}
