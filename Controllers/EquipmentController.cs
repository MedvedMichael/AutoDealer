using AutoDealer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    [ApiController]
    [Route("api/auto")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }
        [HttpGet("equipments")]
        public async Task<IActionResult> GetEquipments([FromQuery] int model, [FromQuery] string search = "")
        {
            var equipments = await equipmentService.GetEquipments(model, search);
            return Ok(equipments);
        }
    }
}