using Everyday.Core.Models;
using Everyday.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everyday.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsumablesController : ControllerBase
    {
        private readonly IConsumableService consumableService;

        public ConsumablesController(IConsumableService consumableService)
        {
            this.consumableService = consumableService;
        }

        [HttpGet]
        [Route("{itemId}/consumable")]
        public async Task<IActionResult> GetConsumableByItemIdAsync([FromRoute] int itemId)
        {
            ConsumableDTO consumable = await consumableService.GetConsumableByItemIdAsync(itemId);

            if (consumable is null)
            {
                return BadRequest();
            }

            return Ok(consumable);
        }

        [HttpGet]
        [Route("consumables")]
        public async Task<IActionResult> GetConsumablesAsync()
        {
            IEnumerable<ConsumableDTO> consumables = await consumableService.GetConsumablesAsync();

            if (!consumables.Any())
            {
                return BadRequest();
            }

            return Ok(consumables);
        }

        [HttpPost]
        [Route("consumable")]
        public async Task<IActionResult> CreateConsumableAsync([FromBody] ConsumableDTO newConsumable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await consumableService.CreateConsumableAsync(newConsumable))
            {
                return BadRequest(ModelState);
            }

            return Ok("Consumable has been created successfully!");
        }

        [HttpPut]
        [Route("consumable")]
        public async Task<IActionResult> UpdateConsumableAsync([FromBody] ConsumableDTO updatedConsumable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await consumableService.UpdateConsumableAsync(updatedConsumable))
            {
                return BadRequest();
            }

            return Ok("Consumable has been updated successfully!");
        }

        [HttpDelete]
        [Route("{id}/consumable")]
        public async Task<IActionResult> DeleteConsumableAsync([FromRoute] int id)
        {
            if (!await consumableService.DeleteConsumableAsync(id))
            {
                return BadRequest(ModelState);
            }

            return Ok("Consumable has been deleted successfully!");
        }
    }
}
