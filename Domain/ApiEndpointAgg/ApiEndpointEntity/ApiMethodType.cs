namespace Domain.ApiEndpointAgg.ApiEndpointEntity
{
    public class ApiMethodType : BaseEntity
    {
        public ApiMethodType()
        {

        }

        public string Method { get; private set; }
        public int GKey { get; private set; }

        public ApiMethodType(string method)
        {
            Method = method;
        }
    }
}
