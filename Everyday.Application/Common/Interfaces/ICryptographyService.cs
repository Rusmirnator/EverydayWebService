using Everyday.Domain.Enums;
using System.Security;

namespace Everyday.Application.Common.Interfaces
{
    public interface ICryptographyService
    {
        public SecureString AESKey { get; }
        public string Encrypt(string rawText);
        public string Decrypt(string encodedText);
        public string CreateDigest(HashingAlgorithm algorithm, string text);
    }
}
