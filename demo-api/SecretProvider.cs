namespace demo_api
{
    public class SecretProvider
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string Url { get; set; }
        public string? AuthKey { get; set; }
        public string? ApplicationId { get; set; }
    }
}
