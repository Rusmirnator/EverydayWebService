using Everyday.Application.Common.Interfaces.Structures;

namespace Everyday.Infrastructure.Common.Options
{
    public class TokenOptions : ITokenOptions
    {
        public int LifetimeMinutes { get; set; }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public TokenOptions(int lifetimeMinutes, string key, string issuer, string audience)
        {
            LifetimeMinutes = lifetimeMinutes;
            Key = key;
            Issuer = issuer;
            Audience = audience;
        }
    }
}
