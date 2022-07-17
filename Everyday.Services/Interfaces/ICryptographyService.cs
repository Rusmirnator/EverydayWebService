namespace Everyday.Services.Interfaces
{
    public interface ICryptographyService
    {
        public string AESKey { get; set; }

        public string Encrypt(string rawText);
        public string Decrypt(string encodedText);
    }
}
