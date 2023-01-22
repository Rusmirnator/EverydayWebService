using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Everyday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManufacturersController : ControllerBase
    {
        [HttpGet]
        [Route("manufacturer")]
        public async Task<IActionResult> GetManufacturerAsync([FromQuery] string name)
        {
            return Ok();
        }

        [HttpGet]
        [Route("manufacturers")]
        public async Task<IActionResult> GetManufacturersAsync()
        {
            return Ok();
        }

        [HttpPost]
        [Route("manufacturer")]
        public async Task<IActionResult> CreateManufacturerAsync([FromBody] object newManufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPut]
        [Route("manufacturer")]
        public async Task<IActionResult> UpdateManufacturerAsync([FromBody] object updatedManufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/manufacturer")]
        public async Task<IActionResult> DeleteManufacturerAsync([FromRoute] int id)
        {
            return Ok();
        }
    }
}