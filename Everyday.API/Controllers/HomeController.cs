using Everyday.API.Authorization.Interfaces;
using Everyday.Core.Models;
using Everyday.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Everyday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public HomeController(IConfiguration config, IUserService userService, ITokenService tokenService)
        {
            this.config = config;
            this.userService = userService;
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

            UserModel validUser = await userService.GetUserAsync(login, password);

            if (validUser is not null)
            {
                string generatedToken = tokenService
                    .BuildToken(config["Jwt:Key"], config["Jwt:Issuer"], config["Jwt:Audience"], validUser);

                if (generatedToken != null && tokenService.ValidateToken(config["Jwt:Key"], config["Jwt:Issuer"], config["Jwt:Audience"], generatedToken))
                {
                    return Ok(generatedToken);
                }
                return StatusCode(500, "Created JWT is invalid!");
            }
            return StatusCode(401, $"Provided login or password is invalid!");
        }
    }
}
