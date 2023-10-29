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
            string? models,
            string? generations,
            string? engines,
            string? equipments,
            string? gearboxes,
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
                Brand = brandId,
                Models = models?.Split(',').Select(int.Parse).ToList(),
                Generations = generations?.Split(',').Select(int.Parse).ToList(),
                Engines = engines?.Split(',').Select(int.Parse).ToList(),
                Equipments = equipments?.Split(',').Select(int.Parse).ToList(),
                Gearboxes = gearboxes?.Split(',').Select(int.Parse).ToList(),
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
            [FromQuery] int? brand,
            [FromQuery] string? models,
            [FromQuery] string? generations,
            [FromQuery] string? engines,
            [FromQuery] string? equipments,
            [FromQuery] string? gearboxes,
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
            var search = ParseSearchAnnouncement(brand,
                models,
                generations,
                engines,
                equipments,
                gearboxes,
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleAnnouncement(int id)
        {
            var saleAnnouncement = await saleAnnouncementService.GetSaleAnnouncement(id);
            return Ok(saleAnnouncement);
        }

    }
}