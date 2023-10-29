using AutoDealer.Data;
using AutoDealer.Entities.DataTransferObjects.Auto;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace AutoDealer.Services
{
    public interface IGenerationService
    {
        Task<List<GenerationDto>> GetGenerations(int modelId, string search);
    }

    public class GenerationService : IGenerationService
    {
        private readonly AutoDbContext db;
        private readonly IMapper mapper;

        public GenerationService(AutoDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<GenerationDto>> GetGenerations(int modelId, string search)
        {
            var model = await db.Models.FindAsync(modelId) ?? throw new KeyNotFoundException();
            var generations = await db.Generations
                .Where(generation => generation.ModelId == modelId && generation.Name.ToLower().Contains(search.ToLower()))
                .Select(x => mapper.Map<GenerationDto>(x)).ToListAsync();

            return generations;
        }
    }
}