namespace ECommerce.WebUı.Settings
{
    public class ClientSetting
    {
        public Client ECommerceVisitorClient { get; set; }
        public Client ECommerceManagerClient { get; set; }
        public Client ECommerceAdminClient { get; set; }

    }

    public class Client 
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
