using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Everyday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemsController : ControllerBase
    {
        [HttpGet]
        [Route("{id}/item")]
        public async Task<IActionResult> GetItemByIdAsync([FromRoute] int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("item")]
        public async Task<IActionResult> GetItemByIdAsync([FromQuery] string code)
        {
            return Ok();
        }

        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> GetItemsAsync()
        {
            return Ok();
        }

        [HttpPost]
        [Route("item")]
        public async Task<IActionResult> CreateItemAsync([FromBody] object newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPut]
        [Route("item")]
        public async Task<IActionResult> UpdateItemAsync([FromBody] object updatedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/item")]
        public async Task<IActionResult> DeleteItemAsync([FromRoute] int id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{code}/item")]
        public async Task<IActionResult> DeleteItemAsync([FromRoute] string code)
        {
            return Ok();
        }
    }
}
