using AutoDealer.Entities.Models.Auto.IntermediateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class EngineGearboxConfiguration : IEntityTypeConfiguration<EngineGearbox>
    {
        public void Configure(EntityTypeBuilder<EngineGearbox> builder)
        {
            builder.HasData(
                new EngineGearbox
                {
                    EnginesId = 1,
                    GearboxesId = 3,
                },
                new EngineGearbox
                {
                    EnginesId = 2,
                    GearboxesId = 4,
                },
                new EngineGearbox
                {
                    EnginesId = 3,
                    GearboxesId = 1,
                }
            );
        }
    }
}