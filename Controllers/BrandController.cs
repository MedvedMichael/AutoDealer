using AutoDealer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    [ApiController]
    [Route("api/auto")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands([FromQuery] string search = "")
        {
            var brands = await brandService.GetBrands(search);
            return Ok(brands);
        }
    }
}