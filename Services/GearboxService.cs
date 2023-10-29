using AutoDealer.Data;
using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Services
{
    public interface IGearboxService
    {
        Task<List<GearboxDto>> GetGearboxes(int engineId, string search);
    }

    public class GearboxService : IGearboxService
    {
        private readonly AutoDbContext db;
        private readonly IMapper mapper;

        public GearboxService(AutoDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<GearboxDto>> GetGearboxes(int engineId, string search)
        {
            var engine = await db.Engines.Include(m => m.Gearboxes).Where(e => e.Id == engineId).FirstAsync() ?? throw new KeyNotFoundException();
            var gearboxes = engine.Gearboxes
                .Where(gearbox => gearbox.Name.ToLower().Contains(search.ToLower()))
                .Select(x => mapper.Map<GearboxDto>(x)).ToList();

            return gearboxes;
        }

    }
}