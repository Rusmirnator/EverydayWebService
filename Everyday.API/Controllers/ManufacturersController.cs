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
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            this.manufacturerService = manufacturerService;
        }

        [HttpGet]
        [Route("{id}/manufacturer")]
        public async Task<IActionResult> GetManufacturerAsync([FromRoute] string name)
        {
            ManufacturerDTO manufacturer = await manufacturerService.GetManufacturerByNameAsync(name);

            if (manufacturer is null)
            {
                return BadRequest();
            }

            return Ok(manufacturer);
        }

        [HttpGet]
        [Route("manufacturers")]
        public async Task<IActionResult> GetManufacturersAsync()
        {
            IEnumerable<ManufacturerDTO> manufacturers = await manufacturerService.GetManufacturersAsync();

            if (!manufacturers.Any())
            {
                return BadRequest();
            }

            return Ok(manufacturers);
        }

        [HttpPost]
        [Route("manufacturer")]
        public async Task<IActionResult> CreateManufacturerAsync([FromBody] ManufacturerDTO newManufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IConveyOperationResult res = await manufacturerService.CreateManufacturerAsync(newManufacturer);

            if (res.StatusCode != 0)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpPut]
        [Route("manufacturer")]
        public async Task<IActionResult> UpdateManufacturerAsync([FromBody] ManufacturerDTO updatedManufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IConveyOperationResult res = await manufacturerService.UpdateManufacturerAsync(updatedManufacturer);

            if (res.StatusCode != 0)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }

        [HttpDelete]
        [Route("{id}/manufacturer")]
        public async Task<IActionResult> DeleteManufacturerAsync([FromRoute] int id)
        {
            IConveyOperationResult res = await manufacturerService.DeleteManufacturerAsync(id);

            if (res.StatusCode != 0)
            {
                return BadRequest(res);
            }

            return Ok(res);
        }
    }
}