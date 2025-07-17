namespace Domain.ApiEndpointAgg.ApiEndpointEntity
{
    public class ApiEndpointType : BaseEntity
    {
        public ApiEndpointType()
        {

        }

        public string Name { get; private set; }
        public int GKey { get; private set; }

        public ApiEndpointType(string name)
        {
            Name = name;
        }
    }
}
