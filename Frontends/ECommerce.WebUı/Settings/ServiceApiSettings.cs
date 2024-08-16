namespace ECommerce.WebUı.Settings
{
    public class ServiceApiSettings
    {
        public string OcelotUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public SerViceApi Catolog { get; set; }
        public SerViceApi Image { get; set; }
        public SerViceApi Discount { get; set; }
        public SerViceApi Order { get; set; }
        public SerViceApi Cargo { get; set; }
        public SerViceApi Basket { get; set; }
        public SerViceApi Comment { get; set; }
        public SerViceApi Payment { get; set; }
    }

    public class SerViceApi 
    {
        public string Path { get; set; }
    }
}
