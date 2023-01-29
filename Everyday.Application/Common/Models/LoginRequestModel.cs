using System.ComponentModel.DataAnnotations;

namespace Everyday.Application.Common.Models
{
    public class LoginRequestModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provided login cannot be empty!")]
        public string? UserUniqueIdentifier { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provided password cannot be empty!")]
        public string? EncodedPassword { get; set; }
    }
}
