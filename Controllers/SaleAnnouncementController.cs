using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoDealer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    [ApiController]
    [Route("api/announcements")]
    public class SaleAnnouncementController : ControllerBase
    {
        private readonly ISaleAnnouncementService saleAnnouncementService;

        public SaleAnnouncementController(ISaleAnnouncementService saleAnnouncementService)
        {
            this.saleAnnouncementService = saleAnnouncementService;
        }

        private SearchAnnouncementDto ParseSearchAnnouncement(
            int? brandId,
            int? modelId,
            int? generationId,
            int? engineId,
            int? equipmentId,
            int? gearboxId,
            int? yearFrom,
            int? yearTo,
            int? mileageFrom,
            int? mileageTo,
            int? priceFrom,
            int? priceTo,
            string? color,
            string? city,
            int? ownersCountFrom,
            int? ownersCountTo
        )
        {
            return new SearchAnnouncementDto
            {
                BrandId = brandId,
                ModelId = modelId,
                GenerationId = generationId,
                EngineId = engineId,
                EquipmentId = equipmentId,
                GearboxId = gearboxId,
                Year = new SearchRange { From = yearFrom, To = yearTo },
                Mileage = new SearchRange { From = mileageFrom, To = mileageTo },
                Price = new SearchRange { From = priceFrom, To = priceTo },
                Color = color,
                City = city,
                OwnersCount = new SearchRange { From = ownersCountFrom, To = ownersCountTo }
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetSaleAnnouncements(
            [FromQuery] int? brandId,
            [FromQuery] int? modelId,
            [FromQuery] int? generationId,
            [FromQuery] int? engineId,
            [FromQuery] int? equipmentId,
            [FromQuery] int? gearboxId,
            [FromQuery] int? yearFrom,
            [FromQuery] int? yearTo,
            [FromQuery] int? mileageFrom,
            [FromQuery] int? mileageTo,
            [FromQuery] int? priceFrom,
            [FromQuery] int? priceTo,
            [FromQuery] string? color,
            [FromQuery] string? city,
            [FromQuery] int? ownersCountFrom,
            [FromQuery] int? ownersCountTo
        )
        {
            var search = ParseSearchAnnouncement(brandId,
                modelId,
                generationId,
                engineId,
                equipmentId,
                gearboxId,
                yearFrom,
                yearTo,
                mileageFrom,
                mileageTo,
                priceFrom,
                priceTo,
                color,
                city,
                ownersCountFrom,
                ownersCountTo);
            var saleAnnouncements = await saleAnnouncementService.GetSaleAnnouncements(search);
            return Ok(saleAnnouncements);
        }


    }
}