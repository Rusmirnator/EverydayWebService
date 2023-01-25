namespace Everyday.Application.Common.Models
{
    public class UserResponseModel
    {
        public string Login { get; set; }
        public List<string> Roles { get; set; }

        public UserResponseModel(string login)
        {
            Login = login;
            Roles = new List<string>();
        }
    }
}
