namespace Domain.HardCodeAgg.HardCodeEntity
{
    public class HardCode : BaseEntity
    {
        public HardCode(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}
