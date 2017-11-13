namespace ProjectName.Business.Core.Models.Configuration
{
    public class CookieAuthenticationConfiguration
    {
        public string AuthenticationScheme { get; set; }
        public string LoginPath { get; set; }
        public string AccessDeniedPath { get; set; }
        public string CookieName { get; set; }

    }
}
