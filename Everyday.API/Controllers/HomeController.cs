using Everyday.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Everyday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly ITokenService tokenService;

        public HomeController(IConfiguration config,ITokenService tokenService)
        {
            this.config = config;
            this.tokenService = tokenService;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromQuery] string login, [FromQuery] string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return StatusCode(400, "Provided login or password has invalid format or is empty!");
            }

            //UserModel validUser = await userService.GetUserAsync(login, password);

            //if (validUser is not null)
            //{
            //    string generatedToken = tokenService
            //        .BuildToken(config["Jwt:Key"], config["Jwt:Issuer"], config["Jwt:Audience"], validUser);

            //    if (generatedToken != null && tokenService.ValidateToken(config["Jwt:Key"], config["Jwt:Issuer"], config["Jwt:Audience"], generatedToken))
            //    {
            //        return Ok(generatedToken);
            //    }
            //    return StatusCode(500, "Created JWT is invalid!");
            //}
            return StatusCode(401, $"Provided login or password is invalid!");
        }
    }
}
