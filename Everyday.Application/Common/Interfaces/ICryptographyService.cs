namespace Everyday.Application.Common.Interfaces
{
    public interface ICryptographyService
    {
        public string AESKey { get; }
        public string Encrypt(string rawText);
        public string Decrypt(string encodedText);
        public string GetSHA256Digest(string text);
    }
}
