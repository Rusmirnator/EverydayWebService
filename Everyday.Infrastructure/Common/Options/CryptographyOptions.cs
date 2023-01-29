using Everyday.Application.Common.Interfaces.Structures;
using Everyday.Infrastructure.Enums;

namespace Everyday.Infrastructure.Common.Options
{
    public class CryptographyOptions : ICryptographyOptions
    {
        public string AesKey { get; set; } = "initialKey";
        public AesType AesType { get; set; } = AesType.AES256;

        public CryptographyOptions(string aesKey, AesType aesType)
        {
            AesKey = aesKey;
            AesType = aesType;
        }
    }
}
