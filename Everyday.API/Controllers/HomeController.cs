using Everyday.Application.Common.Interfaces.Services;
using Everyday.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Everyday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public HomeController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerResponse(400, "Provided login or password is empty or has invalid format!")]
        [SwaggerResponse(401, "Provided login or password is invalid!")]
        [SwaggerResponse(404, "Requested user account does not exist!")]
        [SwaggerResponse(200, "Authenticated successfuly!", typeof(UserResponseModel))]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestModel loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserResponseModel validUser = await identityService.LoginAsync(loginRequest);

            if (validUser is null)
            {
                return NotFound("Requested user account does not exist!");
            }

            if (string.IsNullOrEmpty(validUser.EncodedToken))
            {
                return Unauthorized("Provided login or password is invalid!");
            }

            return Ok(validUser);
        }
    }
}
