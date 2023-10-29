using AutoDealer.Data;
using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Services
{

    public interface ISaleAnnouncementService
    {
        Task<List<SaleAnnouncementDto>> GetSaleAnnouncements();
    }

    public class SaleAnnouncementService : ISaleAnnouncementService
    {

        private readonly AutoDbContext db;
        private readonly IMapper mapper;

        public SaleAnnouncementService(AutoDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<SaleAnnouncementDto>> GetSaleAnnouncements()
        {
            return new List<SaleAnnouncementDto>();
            // var saleAnnouncements = await db.SaleAnnouncements
            //     .Where(saleAnnouncement => saleAnnouncement.Title.ToLower().Contains(search.ToLower()))
            //     .Select(x => mapper.Map<SaleAnnouncementDto>(x)).ToListAsync();

            // return saleAnnouncements;
        }
    }
}