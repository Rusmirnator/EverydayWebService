namespace Everyday.Services.Interfaces
{
    public interface ICryptographyService
    {
        public string Encode(string rawText);
        public string Decode(string encodedText);
    }
}
