using AutoDealer.Data;
using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Services
{

    public interface IEquipmentService
    {
        Task<List<BaseAutoDto>> GetEquipments(int modelId, string search);
    }

    public class EquipmentService : IEquipmentService
    {

        private readonly AutoDbContext db;
        private readonly IMapper mapper;

        public EquipmentService(AutoDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<List<BaseAutoDto>> GetEquipments(int modelId, string search)
        {
            var model = await db.Models.Include(m => m.Equipments).Where(m => m.Id == modelId).FirstAsync() ?? throw new KeyNotFoundException();
            var equipments = model.Equipments
                .Where(equipment => equipment.Name.ToLower().Contains(search.ToLower()))
                .Select(x => mapper.Map<BaseAutoDto>(x))
                .ToList();

            return equipments;
        }
    }
}