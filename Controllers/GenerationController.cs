using AutoDealer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    [ApiController]
    [Route("api/auto")]
    public class GenerationController : ControllerBase
    {
        private readonly IGenerationService generationService;

        public GenerationController(IGenerationService generationService)
        {
            this.generationService = generationService;
        }

        [HttpGet("generations")]
        public async Task<IActionResult> GetGenerations([FromQuery] int model, [FromQuery] string search = "")
        {
            var generations = await generationService.GetGenerations(model, search);
            return Ok(generations);
        }

    }
}