using Everyday.Application.Common.Interfaces.Structures;

namespace Everyday.Application.Common.Interfaces.Services
{
    public interface ICryptographyService
    {
        public ICryptographyOptions? Options { get; set; }

        public string Encrypt(string rawText);
        public string Decrypt(string encodedText);
        public string CreateShaDigest(string text);
    }
}
