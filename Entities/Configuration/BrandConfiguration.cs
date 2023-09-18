using AutoDealer.Entities.Models.Auto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Audi",
                },
                new Brand
                {
                    Id = 2,
                    Name = "BMW",
                },
                new Brand
                {
                    Id = 3,
                    Name = "Mercedes",
                }
            );
        }
    }
}