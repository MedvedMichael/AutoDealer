using AutoDealer.Data;
using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Services
{

    public interface IEngineService
    {
        Task<List<EngineDto>> GetEngines(int modelId, string search);
    }

    public class EngineService : IEngineService
    {
        private readonly AutoDbContext db;
        private readonly IMapper mapper;

        public EngineService(AutoDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<EngineDto>> GetEngines(int modelId, string search)
        {
            var model = await db.Models.Include(m => m.Engines).Where(m => m.Id == modelId).FirstAsync() ?? throw new KeyNotFoundException();
            var engines = model.Engines
                .Where(engine => engine.Name.ToLower().Contains(search.ToLower()))
                .Select(x => mapper.Map<EngineDto>(x)).ToList();

            return engines;
        }
    }
}