using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    [ApiController]
    [Route("api/auto")]
    public class EngineController : ControllerBase
    {
        private readonly IEngineService engineService;

        public EngineController(IEngineService engineService)
        {
            this.engineService = engineService;
        }
        [HttpGet("engines")]
        public async Task<IActionResult> GetEngines([FromQuery] int model, [FromQuery] string search = "")
        {
            var engines = await engineService.GetEngines(model, search);
            return Ok(engines);
        }

    }
}