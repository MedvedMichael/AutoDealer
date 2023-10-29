using AutoDealer.Entities.Models.Auto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class GenerationConfiguration : IEntityTypeConfiguration<Generation>
    {
        public void Configure(EntityTypeBuilder<Generation> builder)
        {
            builder.HasData(
                new Generation
                {
                    Id = 1,
                    Name = "C7",
                    ModelId = 7,
                    StartYear = 2010,
                    EndYear = 2014,
                },
                new Generation
                {
                    Id = 2,
                    Name = "C7 (FL)",
                    ModelId = 7,
                    StartYear = 2014,
                    EndYear = 2018,
                },
                new Generation
                {
                    Id = 3,
                    Name = "C8",
                    ModelId = 7,
                    StartYear = 2018,
                }
            );
        }
    }
}