using AutoDealer.Entities.Models.Auto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class SaleAnnouncementConfiguration : IEntityTypeConfiguration<SaleAnnouncement>
    {
        public void Configure(EntityTypeBuilder<SaleAnnouncement> builder)
        {
            builder.HasData(
                new SaleAnnouncement
                {
                    Id = 1,
                    ModelId = 7,
                    GenerationId = 2,
                    EngineId = 1,
                    GearboxId = 3,
                    EquipmentId = 3,
                    Color = "Blue",
                    Price = 35000,
                    MileageThousands = 100,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla euismod, nisl vitae aliquam ultricies, nunc nisl ultricies",
                    City = "Kyiv",
                    OwnersCount = 1,
                    Year = 2015,
                    WinNumber = "12345678901234567",
                    UserId = "b0d3634c-6328-4814-b095-a0078f357393"
                }
            );
        }
    }
}