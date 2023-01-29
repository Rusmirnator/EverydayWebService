using Everyday.Infrastructure.Enums;

namespace Everyday.Application.Common.Interfaces.Structures
{
    public interface ICryptographyOptions
    {
        public string AesKey { get; }
        public AesType AesType { get; set; }
    }
}
