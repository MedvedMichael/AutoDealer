using AutoDealer.Data;
using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoDealer.Entities.Models.Auto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Services
{
    public interface IAutoService
    {
        Task<List<BaseAutoDto>> GetBrands(string search);
        Task<List<BaseAutoDto>> GetModels(int brandId, string search);
        Task<BaseAutoDto> AddModel(ModelDto modelDto);
        Task<BaseAutoDto> UpdateModel(ModelDto modelDto);
        Task RemoveModel(int modelId);
        Task<List<BaseAutoDto>> GetGenerations(int modelId, string search);
        Task<List<BaseAutoDto>> GetEngines(int modelId, string search);
        Task<SaleAnnouncement> AddAnnouncement();
    }

    public class AutoService : IAutoService
    {
        private readonly AutoDbContext db;
        private readonly IMapper mapper;

        public AutoService(AutoDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public Task<SaleAnnouncement> AddAnnouncement()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BaseAutoDto>> GetBrands(string search)
        {
            var brands = await db.Brands
                .Where(brand => brand.Name.ToLower().Contains(search.ToLower()))
                .Select(x => mapper.Map<BaseAutoDto>(x)).ToListAsync();

            return brands;
        }

        public async Task<List<BaseAutoDto>> GetModels(int brandId, string search)
        {
            var brand = await db.Brands.FindAsync(brandId) ?? throw new KeyNotFoundException();
            var models = await db.Models
                .Where(model => model.BrandId == brandId && model.Name!.ToLower().Contains(search.ToLower()))
                .Select(x => mapper.Map<BaseAutoDto>(x)).ToListAsync();

            return models;
        }

        public async Task<BaseAutoDto> AddModel(ModelDto modelDto)
        {
            var generations = modelDto.Generations.Select(name => mapper.Map<Generation>(name)).ToList();

            var model = mapper.Map<Model>(modelDto);
            model.Generations = generations;
            db.Models.Add(model);

            await db.SaveChangesAsync();

            return mapper.Map<BaseAutoDto>(model);
        }

        public async Task<BaseAutoDto> UpdateModel(ModelDto modelDto)
        {
            var model = await db.Models
                .Include(m => m.Generations)
                .Where(m => m.Id == modelDto.Id)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException();

            var newGenerations = modelDto.Generations
                .Select(name => mapper.Map<Generation>(name)).ToList();

            model.Generations = newGenerations.Select(g =>
            {
                var prevGeneration = model.Generations.Find(generation => generation.Name == g.Name);
                return prevGeneration is not null ? prevGeneration : g;
            }).ToList();

            await db.SaveChangesAsync();

            return mapper.Map<BaseAutoDto>(model);
        }

        public async Task RemoveModel(int modelId)
        {
            var rowsAffected = await db.Models.Where(m => m.Id == modelId).ExecuteDeleteAsync();
            if (rowsAffected == 0)
            {
                throw new KeyNotFoundException();
            }
        }

        public async Task<List<BaseAutoDto>> GetGenerations(int modelId, string search)
        {
            var model = await db.Models.FindAsync(modelId) ?? throw new KeyNotFoundException();
            var generations = await db.Generations
                .Where(generation => generation.ModelId == modelId && generation.Name.ToLower().Contains(search.ToLower()))
                .Select(x => mapper.Map<BaseAutoDto>(x)).ToListAsync();

            return generations;
        }

        public async Task<List<BaseAutoDto>> GetEngines(int modelId, string search)
        {
            var model = await db.Models.FindAsync(modelId) ?? throw new KeyNotFoundException();
            var engines = await db.Engines
                .Where(engine => engine.Models.Exists(m => m.Id == modelId) && engine.Name.ToLower().Contains(search.ToLower()))
                .Select(x => mapper.Map<BaseAutoDto>(x)).ToListAsync();

            return engines;
        }
    }
}