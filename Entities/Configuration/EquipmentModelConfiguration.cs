using AutoDealer.Entities.Models.Auto.IntermediateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class EquipmentModelConfiguration : IEntityTypeConfiguration<EquipmentModel>
    {
        public void Configure(EntityTypeBuilder<EquipmentModel> builder)
        {
            builder.HasData(
                new EquipmentModel
                {
                    EquipmentsId = 1,
                    ModelsId = 7,
                },
                new EquipmentModel
                {
                    EquipmentsId = 2,
                    ModelsId = 7,
                },
                new EquipmentModel
                {
                    EquipmentsId = 3,
                    ModelsId = 7,
                }
            );
        }
    }
}