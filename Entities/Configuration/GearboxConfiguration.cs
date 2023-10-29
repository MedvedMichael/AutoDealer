using AutoDealer.Entities.Models.Auto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class GearboxConfiguration : IEntityTypeConfiguration<Gearbox>
    {
        public void Configure(EntityTypeBuilder<Gearbox> builder)
        {
            builder.HasData(
                new Gearbox
                {
                    Id = 1,
                    Name = "DSG DQ 250",
                    GearboxType = GearboxType.Robotic,
                },
                new Gearbox
                {
                    Id = 2,
                    Name = "DSG DQ 500",
                    GearboxType = GearboxType.Robotic,
                },
                new Gearbox
                {
                    Id = 3,
                    Name = "DSG DQ 381",
                    GearboxType = GearboxType.Robotic,
                },
                new Gearbox
                {
                    Id = 4,
                    Name = "ZF 8HP",
                    GearboxType = GearboxType.Automatic,
                }
            );
        }
    }
}