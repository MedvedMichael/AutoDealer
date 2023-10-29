using AutoDealer.Data;
using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Services
{
    public interface IBrandService
    {
        Task<List<BaseAutoDto>> GetBrands(string search);
    }

    public class BrandService : IBrandService
    {
        private readonly AutoDbContext db;
        private readonly IMapper mapper;
        public BrandService(AutoDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<BaseAutoDto>> GetBrands(string search)
        {
            var brands = await db.Brands
                .Where(brand => brand.Name.ToLower().Contains(search.ToLower()))
                .Select(x => mapper.Map<BaseAutoDto>(x)).ToListAsync();

            return brands;
        }
    }
}