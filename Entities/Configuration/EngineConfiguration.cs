using AutoDealer.Entities.Models.Auto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder.HasData(
                new Engine
                {
                    Id = 1,
                    FuelType = FuelType.Petrol,
                    HorsePower = 333,
                    Capacity = 3.0,
                },
                new Engine
                {
                    Id = 2,
                    FuelType = FuelType.Diesel,
                    HorsePower = 245,
                    Capacity = 3.0,
                },
                new Engine
                {
                    Id = 3,
                    FuelType = FuelType.Petrol,
                    HorsePower = 252,
                    Capacity = 2.0,
                }
            );
        }
    }
}