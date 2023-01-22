using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Everyday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsumablesController : ControllerBase
    {
        [HttpGet]
        [Route("{itemId}/consumable")]
        public async Task<IActionResult> GetConsumableByItemIdAsync([FromRoute] int itemId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("consumable")]
        public async Task<IActionResult> GetConsumableByItemCodeAsync([FromQuery] string itemCode)
        {
            return Ok();
        }

        [HttpGet]
        [Route("consumables")]
        public async Task<IActionResult> GetConsumablesAsync()
        {
            return Ok();
        }

        [HttpPost]
        [Route("consumable")]
        public async Task<IActionResult> CreateConsumableAsync([FromBody] object newConsumable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPut]
        [Route("consumable")]
        public async Task<IActionResult> UpdateConsumableAsync([FromBody] object updatedConsumable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/consumable")]
        public async Task<IActionResult> DeleteConsumableAsync([FromRoute] int id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("consumable")]
        public async Task<IActionResult> DeleteConsumableAsync([FromQuery] string code)
        {
            return Ok();
        }
    }
}
