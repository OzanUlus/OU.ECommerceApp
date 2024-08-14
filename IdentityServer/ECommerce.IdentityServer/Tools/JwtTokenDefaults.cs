namespace ECommerce.IdentityServer.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost"; //yayınlayıcı
        public const string ValidIssuer = "http://localhost";   //dinleyici
        public const string Key = "O&UECommerce..0102030405Asp.NetCore8.0.8*/+-";
        public const int Expire = 60;
    }
}
