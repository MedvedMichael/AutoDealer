using AutoDealer.Data;
using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Services
{

    public interface ISaleAnnouncementService
    {
        Task<List<SaleAnnouncementDto>> GetSaleAnnouncements(SearchAnnouncementDto search);
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

        public async Task<List<SaleAnnouncementDto>> GetSaleAnnouncements(SearchAnnouncementDto search)
        {
            var saleAnnouncements = db.SaleAnnouncements
                .Include(a => a.Model)
                .Include(a => a.User)
                .Include(a => a.Model.Brand)
                .Include(a => a.Generation)
                .Include(a => a.Engine)
                .Include(a => a.Equipment)
                .Include(a => a.Gearbox)
                .Where(a => search.BrandId == null || a.Model.BrandId == search.BrandId)
                .Where(a => search.ModelId == null || a.ModelId == search.ModelId)
                .Where(a => search.GenerationId == null || a.GenerationId == search.GenerationId)
                .Where(a => search.EngineId == null || a.EngineId == search.EngineId)
                .Where(a => search.EquipmentId == null || a.EquipmentId == search.EquipmentId)
                .Where(a => search.GearboxId == null || a.GearboxId == search.GearboxId)
                .Where(a => search.Year == null || search.Year.From == null || a.Year >= search.Year.From)
                .Where(a => search.Year == null || search.Year.To == null || a.Year <= search.Year.To)
                .Where(a => search.Mileage == null || search.Mileage.From == null || a.MileageThousands >= search.Mileage.From)
                .Where(a => search.Mileage == null || search.Mileage.To == null || a.MileageThousands <= search.Mileage.To)
                .Where(a => search.Price == null || search.Price.From == null || a.Price >= search.Price.From)
                .Where(a => search.Price == null || search.Price.To == null || a.Price <= search.Price.To)
                .Where(a => search.OwnersCount == null || search.OwnersCount.From == null || a.OwnersCount >= search.OwnersCount.From)
                .Where(a => search.OwnersCount == null || search.OwnersCount.To == null || a.OwnersCount <= search.OwnersCount.To)
                .Where(a => search.Color == null || a.Color.ToLower().Contains(search.Color.ToLower()))
                .Where(a => search.City == null || a.City.ToLower().Contains(search.City.ToLower()));


            return await saleAnnouncements.Select(x => mapper.Map<SaleAnnouncementDto>(x)).ToListAsync();
        }
    }
}