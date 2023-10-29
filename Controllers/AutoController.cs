using System.Data.Common;
using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoDealer.Entities.Models.Auth;
using AutoDealer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoController : ControllerBase
    {
        private readonly IAutoService autoService;

        public AutoController(IAutoService autoService)
        {
            this.autoService = autoService;
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands([FromQuery] string search = "")
        {
            var brands = await autoService.GetBrands(search);
            return Ok(brands);
        }

        [HttpGet("models")]
        public async Task<IActionResult> GetModels([FromQuery] int brand, [FromQuery] string search = "")
        {
            var brands = await autoService.GetModels(brand, search);
            return Ok(brands);
        }

        [HttpPost("model")]
        [Authorize(Roles = $"{Role.Manager},{Role.Administrator}")]
        public async Task<IActionResult> AddModel([FromBody] ModelDto modelDto)
        {
            var result = await autoService.AddModel(modelDto);
            return Ok(result);
        }

        [HttpPatch("model")]
        [Authorize(Roles = $"{Role.Manager},{Role.Administrator}")]
        public async Task<IActionResult> UpdateModel([FromBody] ModelDto modelDto)
        {
            try
            {
                var result = await autoService.UpdateModel(modelDto);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }



        [HttpDelete("model/{modelId}")]
        [Authorize(Roles = $"{Role.Manager},{Role.Administrator}")]
        public async Task<IActionResult> RemoveModel([FromRoute] int modelId)
        {
            try
            {
                await autoService.RemoveModel(modelId);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        [HttpGet("generations")]
        public async Task<IActionResult> GetGenerations([FromQuery] int model, [FromQuery] string search = "")
        {
            var generations = await autoService.GetGenerations(model, search);
            return Ok(generations);
        }

        [HttpGet("engines")]
        public async Task<IActionResult> GetEngines([FromQuery] int model, [FromQuery] string search = "")
        {
            var engines = await autoService.GetEngines(model, search);
            return Ok(engines);
        }

        [HttpGet("equipments")]
        public async Task<IActionResult> GetEquipments([FromQuery] int model, [FromQuery] string search = "")
        {
            var equipments = await autoService.GetEquipments(model, search);
            return Ok(equipments);
        }
    }
}