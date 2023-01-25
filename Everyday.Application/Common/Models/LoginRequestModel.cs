namespace Everyday.Application.Common.Models
{
    public class LoginRequestModel
    {
        public string? UserUniqueIdentifier { get; set; }
        public string? EncodedPassword { get; set; }
    }
}
