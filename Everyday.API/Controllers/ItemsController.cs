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
    public class ItemsController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        [Route("{id}/item")]
        public async Task<IActionResult> GetItemByIdAsync([FromRoute] int id)
        {
            ItemDTO item = await itemService.GetItemByIdAsync(id);

            if (item is null)
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> GetItemsAsync()
        {
            IEnumerable<ItemDTO> items = await itemService.GetItemsAsync();

            if (!items.Any())
            {
                return BadRequest();
            }

            return Ok(items);
        }

        [HttpPost]
        [Route("item")]
        public async Task<IActionResult> CreateItemAsync([FromBody] ItemDTO newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await itemService.CreateItemAsync(newItem))
            {
                return BadRequest(ModelState);
            }

            return Ok("Item has been created successfully!");
        }

        [HttpPut]
        [Route("item")]
        public async Task<IActionResult> UpdateItemAsync([FromBody] ItemDTO updatedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await itemService.UpdateItemAsync(updatedItem))
            {
                return BadRequest();
            }

            return Ok("Item has been updated successfully!");
        }

        [HttpDelete]
        [Route("{id}/item")]
        public async Task<IActionResult> DeleteItemAsync([FromRoute] int id)
        {
            if (!await itemService.DeleteItemAsync(id))
            {
                return BadRequest(ModelState);
            }

            return Ok("Item has been deleted successfully!");
        }
    }
}
