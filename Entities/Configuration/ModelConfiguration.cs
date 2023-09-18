using AutoDealer.Entities.Models.Auto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasData(
                new Model
                {
                    Id = 1,
                    Name = "A1",
                    BrandId = 1
                },
                new Model
                {
                    Id = 2,
                    Name = "A2",
                    BrandId = 1
                },
                new Model
                {
                    Id = 3,
                    Name = "A3",
                    BrandId = 1
                },
                new Model
                {
                    Id = 4,
                    Name = "A4",
                    BrandId = 1
                },
                new Model
                {
                    Id = 5,
                    Name = "A5",
                    BrandId = 1
                }, new Model
                {
                    Id = 6,
                    Name = "A6",
                    BrandId = 1
                }, new Model
                {
                    Id = 7,
                    Name = "A7",
                    BrandId = 1
                }, new Model
                {
                    Id = 8,
                    Name = "A8",
                    BrandId = 1
                }
            );


        }
    }
}