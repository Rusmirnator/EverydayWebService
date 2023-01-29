namespace Everyday.Application.Common.Interfaces.Structures
{
    public interface ITokenOptions
    {
        public int LifetimeMinutes { get; set; }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
