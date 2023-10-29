using AutoDealer.Entities.Models.Auto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasData(
                new Equipment
                {
                    Id = 1,
                    Name = "Premium",
                },
                new Equipment
                {
                    Id = 2,
                    Name = "Premium Plus (Quattro)",
                },
                new Equipment
                {
                    Id = 3,
                    Name = "Prestige",
                }
            );
        }
    }
}