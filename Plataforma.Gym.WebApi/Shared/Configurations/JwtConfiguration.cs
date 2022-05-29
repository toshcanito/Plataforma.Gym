namespace Plataforma.Gym.WebApi.Shared.Configurations
{
    public class JwtConfiguration
    {
        public string Secret { get; set; } = "3iArcGpJ6WtfKgewYxPlIQ6YhxeOqg77n7T7BSw92r0=";
        public string Audience { get; set; } = "localhost";
        public string Issuer { get; set; } = "localhost";
        public int TokenExpirationInMinutes { get; set; } = 30;
    }
}
