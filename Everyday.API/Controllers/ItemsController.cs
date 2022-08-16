using Everyday.Core.Interfaces;
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
        [Route("{code}/item")]
        public async Task<IActionResult> GetItemByIdAsync([FromRoute] string code)
        {
            ItemDTO item = await itemService.GetItemByCodeAsync(code);

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

            IConveyOperationResult res = await itemService.CreateItemAsync(newItem);

            if (res.StatusCode != 0)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpPut]
        [Route("item")]
        public async Task<IActionResult> UpdateItemAsync([FromBody] ItemDTO updatedItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IConveyOperationResult res = await itemService.UpdateItemAsync(updatedItem);

            if (res.StatusCode != 0)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpDelete]
        [Route("{id}/item")]
        public async Task<IActionResult> DeleteItemAsync([FromRoute] int id)
        {
            IConveyOperationResult res = await itemService.DeleteItemAsync(id);

            if (res.StatusCode != 0)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpDelete]
        [Route("{code}/item")]
        public async Task<IActionResult> DeleteItemAsync([FromRoute] string code)
        {
            IConveyOperationResult res = await itemService.DeleteItemAsync(code);

            if (res.StatusCode != 0)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }
    }
}
