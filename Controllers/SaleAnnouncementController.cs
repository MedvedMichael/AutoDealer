using AutoDealer.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Controllers
{
    public class SaleAnnouncementController : ControllerBase
    {
        private readonly ISaleAnnouncementService saleAnnouncementService;

        public SaleAnnouncementController(ISaleAnnouncementService saleAnnouncementService)
        {
            this.saleAnnouncementService = saleAnnouncementService;
        }
    }
}