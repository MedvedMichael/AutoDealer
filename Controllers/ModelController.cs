using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoDealer.Entities.Models.Auth;
using AutoDealer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    [ApiController]
    [Route("api/auto")]
    public class ModelController : ControllerBase
    {
        private readonly IModelService modelService;

        public ModelController(IModelService modelService)
        {
            this.modelService = modelService;
        }

        [HttpGet("models")]
        public async Task<IActionResult> GetModels([FromQuery] int brand, [FromQuery] string search = "")
        {
            var brands = await modelService.GetModels(brand, search);
            return Ok(brands);
        }

        [HttpPost("model")]
        [Authorize(Roles = $"{Role.Manager},{Role.Administrator}")]
        public async Task<IActionResult> AddModel([FromBody] ModelDto modelDto)
        {
            var result = await modelService.AddModel(modelDto);
            return Ok(result);
        }

        [HttpPatch("model")]
        [Authorize(Roles = $"{Role.Manager},{Role.Administrator}")]
        public async Task<IActionResult> UpdateModel([FromBody] ModelDto modelDto)
        {
            try
            {
                var result = await modelService.UpdateModel(modelDto);
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
                await modelService.RemoveModel(modelId);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}