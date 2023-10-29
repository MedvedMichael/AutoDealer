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
    public class GearboxController : ControllerBase
    {
        private readonly IGearboxService gearboxService;

        public GearboxController(IGearboxService gearboxService)
        {
            this.gearboxService = gearboxService;
        }

        [HttpGet("gearboxes")]
        public async Task<IActionResult> GetGearboxes([FromQuery] int engine, [FromQuery] string search = "")
        {
            var gearboxes = await gearboxService.GetGearboxes(engine, search);
            return Ok(gearboxes);
        }
    }
}